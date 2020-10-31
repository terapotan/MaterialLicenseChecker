using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Reflection;
using System.Xml.Linq;
using System.Security;
using System.IO;

using MyException = MaterialLicenseChecker.MyException;

namespace MaterialLicenseChecker.Models
{
    /// <summary>
    /// LicenseTexts.xml(素材配布サイト管理ファイル)の読み書きを行うクラス。
    /// </summary>
    public class MaterialSiteListFileAdapter
    {
        private XDocument _loadedXMLFileInstance;

        ///<summary>
        ///引数のどちらかが空文字列("")のときに、この数値が例外メッセージとして返却される
        ///</summary>
        public static readonly int VALUE_EMPTY = 1;
        /// <summary>
        /// 素材配布サイトを追加する際、既にその配布サイトが登録されている場合、この数値が例外メッセージとして返却される。
        /// </summary>
        public static readonly int REGISTER_EXISTS_MATERIALSITE = 2;


        public MaterialSiteListFileAdapter()
        {
            _loadedXMLFileInstance = XDocument.Load(StoringDataFilePath.GetInstance().LicenseTextFileAbsolutePath);
        }

        public string FetchLicenseTextGivenSiteName(string SearchedSiteName)
        {
            //TODO:インジェクション攻撃に備え一応エスケープしておいた。
            //一応、というだけでちゃんとした対策ではないが……
            //後で時間があればちゃんとやるように。
            var SearchedMaterialSite = _loadedXMLFileInstance.XPathSelectElement("//materialSite[@siteName='" + SecurityElement.Escape(SearchedSiteName) + "']");

            return SearchedMaterialSite.Element("licenseText").Value;

        }

        /// <summary>
        /// 指定されたサイト名が存在すればTrue,しなければFalseを返却する。
        /// </summary>
        /// <param name="SearchedSiteName"></param>
        /// <returns></returns>
        public bool MaterialSiteExists(string SearchedSiteName)
        {
            var SearchedMaterialSite = _loadedXMLFileInstance.XPathSelectElement("//materialSite[@siteName='" + SecurityElement.Escape(SearchedSiteName) + "']");

            //FIXME:nullチェックって……何か、どうにかできなかったっけ?
            if(SearchedMaterialSite == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// <para>
        /// ライセンス文を追加するメソッド。サイト名の重複などがあった場合は、以下の定数のメッセージを含めたArgumentExceptionを送出する。なお、追加した内容は即ファイルに書き出される。
        /// </para>
        /// <para>VALUE_EMPTY:どちらかの入力値が空</para>
        /// <para>REGISTER_EXISTS_MATERIALSITE:指定された配布サイトが既に登録されている</para>
        /// </summary>
        /// <param name="SiteName"></param>
        /// <param name="LicenseText"></param>
        public void AddLicenseText(string SiteName, string TeamsOfUseURL, string LicenseText, string MemoOfMaterialSite)
        {
            //以下引数チェック処理。

            //サイト名が、空文字列("")である場合
            if (SiteName.Equals(""))
            {
                throw new ArgumentException(VALUE_EMPTY.ToString());
            }

            if (MaterialSiteExists(SiteName))
            {
                throw new ArgumentException(REGISTER_EXISTS_MATERIALSITE.ToString());
            }

            //追加するmaterialSite要素を作成する
            XElement AddedMaterialSiteTree = new XElement("materialSite",
                new XElement("licenseText",LicenseText),
                new XElement("teamsOfUseURL",TeamsOfUseURL),
                new XElement("licenseMemo",MemoOfMaterialSite));

            //サイト名の追加
            AddedMaterialSiteTree.SetAttributeValue("siteName", SiteName);

            _loadedXMLFileInstance.Elements().First().Add(AddedMaterialSiteTree);
            _loadedXMLFileInstance.Save(StoringDataFilePath.GetInstance().LicenseTextFileAbsolutePath);
        }

        //FIXME:しょうがないから、IEnumerable型にしたけど、
        //後でちゃんと直さないとだめだな……

        /// <summary>
        /// SiteNameListで指定されたサイトの利用規約をリストにして返却する。
        /// SiteNameListにまだ登録されていないサイト名を入力すると
        /// ソフトウェアが強制終了する。
        /// </summary>
        /// <param name="SiteNameList">gg</param>
        /// <returns>
        /// </returns>
        public List<string> GetLicenseTextLists(IEnumerable<string> SiteNameList)
        {
            List<string> ReturnList = new List<string>();


            foreach (var SiteName in SiteNameList)
            {
                ReturnList.Add(FetchLicenseTextGivenSiteName(SiteName));
            }

            return ReturnList;

        }

        public List<string> GetMaterialSiteList()
        {
            var materialSites = _loadedXMLFileInstance.XPathSelectElement("/document");
            IEnumerable<XElement> elements = from el in materialSites.Elements() select el;

            var MaterialSiteList = new List<string>();

            foreach (XElement el in elements)
            {
                MaterialSiteList.Add(el.Attribute("siteName").Value);
            }

            return MaterialSiteList;
        }

        /// <summary>
        /// 与えられたMaterialSiteNameの内容を、MaterialSiteDataクラスにまとめて返却します。
        /// </summary>
        /// <param name="MaterialSiteName"></param>
        /// <returns></returns>
        public MaterialSiteData GetMaterialSite(string SearchedSiteName)
        {
            //FIXME:後でサイトが見つからない時の処理も実装しておくこと。
            var SearchedMaterialSite = _loadedXMLFileInstance.XPathSelectElement("//materialSite[@siteName='" + SecurityElement.Escape(SearchedSiteName) + "']");
            
            //もしサイトが見つからない場合
            if(SearchedMaterialSite == null)
            {
                throw new MyException.NotFoundMaterialSiteException();
            }

            MaterialSiteData ReturnedSiteData = new MaterialSiteData();
            ReturnedSiteData.LicenseMemo = SearchedMaterialSite.Element("licenseMemo").Value;
            ReturnedSiteData.LicenseText = SearchedMaterialSite.Element("licenseText").Value;
            ReturnedSiteData.TeamsOfURL = SearchedMaterialSite.Element("teamsOfUseURL").Value;
            ReturnedSiteData.MaterialSiteName = SearchedSiteName;

            return ReturnedSiteData;
        }

        /// <summary>
        /// 素材データを削除するメソッド。
        /// </summary>
        /// <param name="MaterialSiteName"></param>
        public void DeleteMaterialSite(string MaterialSiteName)
        {
            var SearchedMaterialSite = _loadedXMLFileInstance.XPathSelectElement("//materialSite[@siteName='" + SecurityElement.Escape(MaterialSiteName) + "']");
            
            //もしサイトが見つからない場合
            if (SearchedMaterialSite == null)
            {
                throw new MyException.NotFoundMaterialSiteException();
            }


            SearchedMaterialSite.Remove();

            _loadedXMLFileInstance.Save(StoringDataFilePath.GetInstance().LicenseTextFileAbsolutePath);

        }
    }
}
