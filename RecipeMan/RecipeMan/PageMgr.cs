using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipeMan
{
    static class PageMgr
    {
        internal static List<RecipeDetail> RecipeList = null;

        static public void ViewMainPage()
        {
            RecipeList = RecipeDataStorage.GetAllList();
            Application.Current.MainPage = new MainPage(RecipeList);      /* HOME画面 */
        }

        static public void ViewRegistPage(int ID)
        {
            
            RecipeList = RecipeDataStorage.GetAllList();

            if (RecipeDataStorage.GetTempRecipe() != null)  /* 材料追加画面から登録画面へ戻る場合 */
            {
                RecipeDetail recipeDetail = RecipeDataStorage.GetTempRecipe();
                if(RecipeList.Count != 0)
                {
                    RecipeList.RemoveAt(recipeDetail.ID);
                }
                RecipeList.Insert(recipeDetail.ID, recipeDetail);
            }
            //RecipeList = RecipeDataStorage.GetAllList();
            Application.Current.MainPage = new RegistPage(RecipeList, ID);    /* レシピ登録画面 */
        }

        static public void ViewMaterialPage(int ID)
        {
            Application.Current.MainPage = new MaterialPage(ID);    /* 材料入力画面 */
        }

        static public void ViewRecipeListPage()
        {
            RecipeList = RecipeDataStorage.GetAllList();
            Application.Current.MainPage = new RecipeListPage(RecipeList);    /* レシピ一覧画面 */
        }

        static public void ViewDisplayRecipePage(int ID)
        {
            Application.Current.MainPage = new DisplayRecipePage(ID);           /* レシピ参照画面 */
        }
    }
}
