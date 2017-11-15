using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//using System.IO.IsolatedStorage;

using Xamarin.Forms;
using PCLStorage;

namespace RecipeMan
{
    public partial class App : Application
    {
        List<RecipeDetail> AllList = new List<RecipeDetail>();      /* 全てのレシピデータ */
        List<RecipeDetail> NewRecipeData = new List<RecipeDetail>();      /* 新規のレシピデータ */
        private const string Recipe = "Recipe";

        public App()
        {
            InitializeComponent();

            /* 端末への保存データの取得 */
            if (Application.Current.Properties.ContainsKey(Recipe))
            {
                AllList = Application.Current.Properties[Recipe] as List<RecipeDetail>;
            }
            RecipeDataStorage.AllList = AllList;
            RecipeDataStorage.SetIDList();

            PageMgr.ViewMainPage();
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
            /* 端末への保存データの取得 */
            if( Application.Current.Properties.ContainsKey( Recipe ) )
            {
                AllList = Application.Current.Properties[Recipe] as List<RecipeDetail>;
            }
            RecipeDataStorage.AllList = AllList;
            RecipeDataStorage.SetIDList();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            /* 端末への保存データの保存 */
            NewRecipeData = RecipeDataStorage.GetAllList();
            Application.Current.Properties[Recipe] = NewRecipeData;
            Application.Current.SavePropertiesAsync();

            if (RecipeDataStorage.AllList.Count != 0 && RecipeDataStorage.AllList != null)
            {
                //SaveTextAsync(RecipeDataStorage.AllList[RecipeDataStorage.AllList.Count - 1].Name);
                SaveTextAsync(GetRecipeInfoData());

            }
        }
        
        protected override void OnResume()
        {
            // Handle when your app resumes
            /* 端末への保存データの保存 */
            NewRecipeData = RecipeDataStorage.GetAllList();
            Application.Current.Properties[Recipe] = NewRecipeData;
            Application.Current.SavePropertiesAsync();
        }

        async void SaveTextAsync(string text)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage; //<- 1
            IFile file = await rootFolder.CreateFileAsync(RecipeDataStorage.dataName, CreationCollisionOption.OpenIfExists); // <- 2
            await file.WriteAllTextAsync(text);
        }

        string GetRecipeInfoData()
        {
            string data = string.Empty;
            foreach(RecipeDetail detail in RecipeDataStorage.AllList)
            {
                data += detail.Name + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.NAME];
/*                data += detail.Material1 + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.MATERIAL1];
                data += detail.Amount1 + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.AMOUNT1];
*/                data += detail.Category1 + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.CATEGORY1];
                data += detail.Category2 + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.CATEGORY2];
                data += detail.Hour + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.HOUR];
                data += detail.Minute + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.MINUTE];
                data += detail.HowToMake + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.HOWTO_MAKE];
                data += detail.Memo + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.MEMO];
                data += detail.ID.ToString() + RecipeDataStorage.dataTagList[(int)RecipeDataStorage.TagSeries.ID];
            }
            return data;
        }
    }
}
