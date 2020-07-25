using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Reflection;
using System.Xml.Linq;
using System.Security;

namespace MaterialLicenseChecker.Models
{
    class ClassStoreLicenseText
    {
        private XDocument _loadedXMLFileInstance;

        /// <summary>
        /// ライセンステキストを辞書型で保管する。
        /// 1番目:利用規約のサイト名(キーとなる)
        /// 2番目:利用規約の内容(テキスト)
        /// </summary>
        private Dictionary<string, string> _licenseTextDictionary;

        //将来的には、2番目のstringは単なる文字列ではなく、ユーザー定義のクラスとなるだろう。
        //まぁ先のことだ。

        //FIXME:現状このクラスで、ファイルの読み書きを行っている。
        //別のクラスに分離し、こちら側はファイルから特定のサイト名のライセンステキストを出力してもらう
        //関数を呼び出すだけにしておきたい。


        public ClassStoreLicenseText()
        {
            //FIXME:ここらへんの処理を毎回書くのは面倒である。
            //よって、別のまぁシングルトンクラスに移したい。
            //シングルトンクラスに以下のコードを移すこと。
            Assembly assembly = Assembly.GetEntryAssembly();
            string runingFilePath = assembly.Location;
            System.IO.FileInfo fi = new System.IO.FileInfo(runingFilePath);
            string runingDirectoryPath = fi.Directory.FullName;

            _loadedXMLFileInstance = XDocument.Load(runingDirectoryPath + "/ExportResources/LicenseTexts.xml");  ;

            _licenseTextDictionary = new Dictionary<string,string>();
            _licenseTextDictionary.Add("A", _fetchLicenseTextGivenSiteName("A"));
            _licenseTextDictionary.Add("B", _fetchLicenseTextGivenSiteName("B"));
            _licenseTextDictionary.Add("C", _fetchLicenseTextGivenSiteName("C"));
            _licenseTextDictionary.Add("D", _fetchLicenseTextGivenSiteName("D"));
            _licenseTextDictionary.Add("E", _fetchLicenseTextGivenSiteName("E"));
        }

        private string _fetchLicenseTextGivenSiteName(string SearchedSiteName)
        {
            //TODO:インジェクション攻撃に備え一応エスケープしておいた。
            //一応、というだけでちゃんとした対策ではないが……
            //後で時間があればちゃんとやるように。
            var SearchedMaterialSite = _loadedXMLFileInstance.XPathSelectElement("//materialSite[@siteKey='" + SecurityElement.Escape(SearchedSiteName) + "']");

            return SearchedMaterialSite.Element("licenseText").Value;

        }

        /// <summary>
        /// SiteNameListで指定されたサイトの利用規約をリストにして返却する。
        /// SiteNameListにまだ登録されていないサイト名を入力すると
        /// ソフトウェアが強制終了する。
        /// </summary>
        /// <param name="SiteNameList">gg</param>
        /// <returns>
        /// </returns>
        public List<String> GetLicenseTextLists(in List<string> SiteNameList)
        {
            List<String> ReturnList = new List<String>();


            foreach (var SiteName in SiteNameList)
            {
                ReturnList.Add(_licenseTextDictionary[SiteName]);
            }

            return ReturnList;

        }
    }
}
