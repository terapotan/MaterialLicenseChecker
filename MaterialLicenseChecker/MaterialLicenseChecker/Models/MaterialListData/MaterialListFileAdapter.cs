﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Security;

namespace MaterialLicenseChecker.Models
{
    public class MaterialListFileAdapter
    {
        private XDocument LoadedXMLFileInstance;

        public MaterialListFileAdapter()
        {
            LoadedXMLFileInstance = XDocument.Load(StoringDataFilePath.GetInstance().MaterialListFileAbsolutePath);
        }

        /// <summary>
        /// 素材データを追加するメソッド。妥当性チェックは行わない。
        /// </summary>
        /// <param name="SiteName"></param>
        /// <param name="LicenseText"></param>
        public void AddMaterialData(string MaterialName, string MaterialFilePath,string MaterialSiteName)
        {
            XElement AddedMaterialTree = new XElement("material", 
                new XElement("materialCreationSiteName", MaterialSiteName),
                new XElement("materialFileAbsolutePath", MaterialFilePath));

            AddedMaterialTree.SetAttributeValue("materialName", MaterialName);
            LoadedXMLFileInstance.Elements().First().Add(AddedMaterialTree);

            LoadedXMLFileInstance.Save(StoringDataFilePath.GetInstance().MaterialListFileAbsolutePath);
        }

        /// <summary>
        /// 素材データを削除するメソッド。妥当性チェックはもちろん行わない。
        /// </summary>
        /// <param name="MaterialName"></param>
        public void DeleteMaterialData(string MaterialName)
        {
            var SearchedMaterialElement = LoadedXMLFileInstance.XPathSelectElement("//material[@materialName='" + SecurityElement.Escape(MaterialName) + "']");

            SearchedMaterialElement.Remove();

            LoadedXMLFileInstance.Save(StoringDataFilePath.GetInstance().MaterialListFileAbsolutePath);

        }

        /// <summary>
        /// 素材名の一覧をリスト形式で取得する
        /// </summary>
        /// <returns></returns>
        public List<string> GetMaterialNameList()
        {
            var materialNames = LoadedXMLFileInstance.XPathSelectElement("/document");
            IEnumerable<XElement> elements = from el in materialNames.Elements() select el;

            var MaterialNameList = new List<string>();

            foreach (XElement el in elements)
            {
                MaterialNameList.Add(el.Attribute("materialName").Value);
            }

            return MaterialNameList;
        }

        /// <summary>
        /// 素材名から、その素材の配布元サイト名を取得する。
        /// </summary>
        /// <param name="SiteName"></param>
        /// <returns></returns>
        public string FetchMaterialSiteGivenMaterialName(string MaterialName)
        {
            var SearchedMaterialElement = LoadedXMLFileInstance.XPathSelectElement("//material[@materialName='" + SecurityElement.Escape(MaterialName) + "']");
            return SearchedMaterialElement.Element("materialCreationSiteName").Value;
        }
    }
}
