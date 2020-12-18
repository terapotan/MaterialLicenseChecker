using System;
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
        public void AddMaterialData(MaterialData AddedMaterialData)
        {
            XElement AddedMaterialTree = new XElement("material",
                new XElement("materialType", AddedMaterialData.MaterialType),
                new XElement("materialCreationSiteName", AddedMaterialData.MaterialCreationSiteName),
                new XElement("materialFileAbsolutePath", AddedMaterialData.MaterialFileAbsolutePath));

            AddedMaterialTree.SetAttributeValue("materialName", AddedMaterialData.MaterialName);
            LoadedXMLFileInstance.Elements().First().Add(AddedMaterialTree);

            LoadedXMLFileInstance.Save(StoringDataFilePath.GetInstance().MaterialListFileAbsolutePath);
        }

        /// <summary>
        /// 素材データを削除するメソッド。妥当性チェックはもちろん行わない。
        /// </summary>
        /// <param name="MaterialName"></param>
        public void DeleteMaterialData(string MaterialName)
        {
            LoadedXMLFileInstance.XPathSelectElement("//material[@materialName='" + SecurityElement.Escape(MaterialName) + "']").Remove();
            LoadedXMLFileInstance.Save(StoringDataFilePath.GetInstance().MaterialListFileAbsolutePath);

        }

        /// <summary>
        /// ファイルに登録されているすべての素材データを読み出す
        /// </summary
        /// <returns></returns>
        public void GetMaterialList(List<MaterialData> OutputMaterialData)
        {
            var materialNames = LoadedXMLFileInstance.XPathSelectElement("/document");
            IEnumerable<XElement> elements = from el in materialNames.Elements() select el;


            foreach (XElement el in elements)
            {
                OutputMaterialData.Add(new MaterialData(el.Attribute("materialName").Value,
                    el.Element("materialCreationSiteName").Value,
                    el.Element("materialType").Value,
                    el.Element("materialFileAbsolutePath").Value));
            }
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

        /// <summary>
        /// MaterialNameの素材データのみ読み出す
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <returns></returns>
        public MaterialData FetchMaterialData(string MaterialName)
        {
            MaterialData ReturnedMaterialData = new MaterialData();
            var SearchedMaterialElement = LoadedXMLFileInstance.XPathSelectElement("//material[@materialName='" + SecurityElement.Escape(MaterialName) + "']");
            
            ReturnedMaterialData.MaterialName = MaterialName;
            ReturnedMaterialData.MaterialCreationSiteName = SearchedMaterialElement.Element("materialCreationSiteName").Value;
            ReturnedMaterialData.MaterialType = SearchedMaterialElement.Element("materialType").Value;
            ReturnedMaterialData.MaterialFileAbsolutePath = SearchedMaterialElement.Element("materialFileAbsolutePath").Value;

            return ReturnedMaterialData;
        }
    }
}
