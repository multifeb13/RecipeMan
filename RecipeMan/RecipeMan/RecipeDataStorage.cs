using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipeMan
{
    public class RecipeDetail
    {
        public int ID { get; set; }                                 /* レシピID */
        public string Name { get; set; }                            /* 料理名 */
        public List<MaterialAndAmount> MaterialAndAmountList { get; set; }   /* 材料、分量 */
        public string Category1 { get; set; }                       /* カテゴリ1 */
        public string Category2 { get; set; }                       /* カテゴリ2 */
        public int Hour { get; set; }                               /* 時間 */
        public int Minute { get; set; }                             /* 分 */
        public string HowToMake { get; set; }                       /* 作り方 */
        public string Memo { get; set; }                            /* メモ */
    }

    public class MaterialAndAmount
    {
        public string Material { get; set; }    /* 材料 */
        public string Amount { get; set; }      /* 分量 */
    }

    static class RecipeDataStorage
    {
        internal static List<RecipeDetail> AllList;
        internal static List<int> IDList = new List<int>();
        internal static RecipeDetail TempRecipe = null;

        internal enum TagSeries
        {
            NAME,
            MATERIAL1,
            AMOUNT1,
            CATEGORY1,
            CATEGORY2,
            HOUR,
            MINUTE,
            HOWTO_MAKE,
            MEMO,
            ID,
            NUM_OF_SERIES,
        }

        internal static string dataName = "allData.txt";
        internal static string[] dataTagList = { "[NAME_TAG]", "[MATERIAL1_TAG]", "[AMOUNT1_TAG]", "[CATEGORY1_TAG]", "[CATEGORY2_TAG]", "[HOUR_TAG]", "[MINUTE_TAG]", "[HOWTOMAKE_TAG]", "[MEMO_TAG]", "[ID_TAG]" };

        /* 初期IDを設定 */
        static public void SetIDList()
        {
            foreach (RecipeDetail detail in AllList)
            {
                IDList.Add(detail.ID);
            }
            if (IDList == null)
            {
                IDList.Add(0);
            }
        }

        /* アプリ上のレシピリスト情報を取得 */
        static public List<RecipeDetail> GetAllList()
        {
            return AllList;
        }

        /* アプリ上でレシピリスト情報を保存 */
        static public void SaveAllList( List<RecipeDetail> List )
        {
            AllList = List;
            SetIDList();
        }

        /* 選択したIDのレシピ情報を取得 */
        static public RecipeDetail GetSelectRecipeData( int ID )
        {
            foreach ( RecipeDetail detail in AllList )
            {
                if ( detail.ID == ID )    return detail;
            }
            return null;
        }
        
        /* 新規レシピ登録用のIDを取得 */
        static public int GetNewRecipeListID( )
        {
            int count = 0;
            foreach (RecipeDetail detail in AllList)
            {
                int index = IDList.IndexOf(count);
                if (index == -1)    return count;
                count++;
            }
            return count;
        }

        /* レシピIDからリストのindex番号を取得 */
        static public int GetListIDfromRecipe(int ID)
        {
            int index = IDList.IndexOf(ID);
            return index;
        }

        /* 編集中のレシピ情報を一時保管 */
        static public void SetTempRecipe(RecipeDetail Temp)
        {
            TempRecipe = Temp;
        }

        /* 一時保管した編集中のレシピ情報を取得 */
        static public RecipeDetail GetTempRecipe()
        {
            return TempRecipe;
        }

        /* 一時保管した編集中のレシピ情報を削除：一時保管して不要になったら要削除!! */
        static public void ClearTempRecipe()
        {
            TempRecipe = null;
        }
    }
}
