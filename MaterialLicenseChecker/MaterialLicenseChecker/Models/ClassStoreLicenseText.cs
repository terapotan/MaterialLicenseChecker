using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Models
{
    class ClassStoreLicenseText
    {
        /// <summary>
        /// ライセンステキストを辞書型で保管する。
        /// 1番目:利用規約のサイト名(キーとなる)
        /// 2番目:利用規約の内容(テキスト)
        /// </summary>
        private Dictionary<string, string> _licenseTextDictionary;

        //将来的には、2番目のstringは単なる文字列ではなく、ユーザー定義のクラスとなるだろう。
        //まぁ先のことだ。

        public ClassStoreLicenseText()
        {
            _licenseTextDictionary = new Dictionary<string,string>();
            _licenseTextDictionary.Add("A", "サイトAの利用規約");
            _licenseTextDictionary.Add("B", "サイトBの利用規約");
            _licenseTextDictionary.Add("C", "サイトCの利用規約");
            _licenseTextDictionary.Add("D", "サイトDの利用規約");
            _licenseTextDictionary.Add("E", "サイトEの利用規約");

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
