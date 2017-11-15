using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeMan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeListPage : ContentPage
    {
        ObservableCollection<RecipeDetail> RecipeData = new ObservableCollection<RecipeDetail>();

        public RecipeListPage( List<RecipeDetail> AllList )
        {
            InitializeComponent();
            
            RecipeList.ItemsSource = RecipeData;

            foreach ( RecipeDetail detail in AllList )
            {
                if (RecipeData == null) RecipeData = new ObservableCollection<RecipeDetail>();
                RecipeData.Add(new RecipeDetail { ID = detail.ID,
                                                  Name = detail.Name,
                                                  MaterialAndAmountList = detail.MaterialAndAmountList,
                                                  /*Material1 = detail.Material1,
                                                  Amount1 = detail.Amount1,
                                                  */Category1 = detail.Category1,
                                                  Category2 = detail.Category2,
                                                  Hour = detail.Hour,
                                                  Minute = detail.Minute,
                                                  HowToMake = detail.HowToMake,
                                                  Memo = detail.HowToMake });
            }
        }

        private void RecipeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            RecipeDetail Recipe = (RecipeDetail)e.Item;
            PageMgr.ViewDisplayRecipePage( Recipe.ID );     /* レシピ参照画面 */
        }

        private void GoRegistPage(object sender, System.EventArgs e)
        {
            PageMgr.ViewRegistPage( RecipeDataStorage.GetNewRecipeListID( ) );  /* レシピ登録画面 */
        }

        private void BackHome(object sender, System.EventArgs e)
        {
            PageMgr.ViewMainPage(); /* HOME画面 */
        }
    }
}