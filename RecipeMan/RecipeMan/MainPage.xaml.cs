using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLStorage;

namespace RecipeMan
{
    public partial class MainPage : ContentPage
    {
        public MainPage(List<RecipeDetail> AllList)
        {
            InitializeComponent();

            if (AllList == null || AllList.Count == 0)
            {
                LoadTextAsync();
            }

            RecipeListPageBtn.Clicked += (sender, e) =>
            {
                PageMgr.ViewRecipeListPage();                   /* レシピ一覧ページへ移動 */
            };

            RegistPageBtn.Clicked += (sender, e) =>
            {
                PageMgr.ViewRegistPage(RecipeDataStorage.GetNewRecipeListID());  /* レシピ登録ページへ移動 */
            };
        }

        async void LoadTextAsync()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            List<RecipeDetail> RecipeList = null;
            string allData = string.Empty;
            
            ExistenceCheckResult res = await rootFolder.CheckExistsAsync(RecipeDataStorage.dataName);
            if (res == ExistenceCheckResult.FileExists)
            {
                IFile file = await rootFolder.GetFileAsync(RecipeDataStorage.dataName);
                allData = await file.ReadAllTextAsync();
            }
            else
            {
                return;
            }
#if false
            RecipeDetail detail = new RecipeDetail();
            detail.Name = name;
            RecipeList.Add(detail);
#else
            RecipeList = ParseDataToRecipeList(allData);
#endif

            /* 内容保存 */
            RecipeDataStorage.SaveAllList(RecipeList);
        }

        List<RecipeDetail> ParseDataToRecipeList(string data)
        {
            List<RecipeDetail> RecipeList = new List<RecipeDetail>();
            bool roop = true;
            while (roop)
            {
                RecipeDetail detail = new RecipeDetail();
                for(int i = 0;i < (int)RecipeDataStorage.TagSeries.NUM_OF_SERIES; i++)
                {
                    int targetIndex = data.IndexOf(RecipeDataStorage.dataTagList[i]);
                    if (targetIndex == -1)
                    {
                        roop = false;
                        break;
                    }
                    string inputData = data.Substring(0, targetIndex);
                    
                    switch (i)
                    {
                        case (int)RecipeDataStorage.TagSeries.NAME:
                            detail.Name = inputData;
                            break;
/*                        case (int)RecipeDataStorage.TagSeries.MATERIAL1:
                            detail.Material1 = inputData;
                            break;
                        case (int)RecipeDataStorage.TagSeries.AMOUNT1:
                            detail.Amount1 = inputData;
                            break;
*/                        case (int)RecipeDataStorage.TagSeries.CATEGORY1:
                            detail.Category1 = inputData;
                            break;
                        case (int)RecipeDataStorage.TagSeries.CATEGORY2:
                            detail.Category2 = inputData;
                            break;
                        case (int)RecipeDataStorage.TagSeries.HOUR:
                            detail.Hour = int.Parse(inputData);
                            break;
                        case (int)RecipeDataStorage.TagSeries.MINUTE:
                            detail.Minute = int.Parse(inputData);
                            break;
                        case (int)RecipeDataStorage.TagSeries.HOWTO_MAKE:
                            detail.HowToMake = inputData;
                            break;
                        case (int)RecipeDataStorage.TagSeries.MEMO:
                            detail.Memo = inputData;
                            break;
                        case (int)RecipeDataStorage.TagSeries.ID:
                            detail.ID = int.Parse(inputData);
                            break;
                    }
                    data = data.Remove(0, targetIndex + RecipeDataStorage.dataTagList[i].Length);
                }
                if (roop)
                {
                    RecipeList.Add(detail);
                }
            }
            return RecipeList;
        }
    }
}