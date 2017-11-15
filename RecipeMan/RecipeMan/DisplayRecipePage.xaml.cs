using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeMan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayRecipePage : ContentPage
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public string Amount { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string HowToMake { get; set; }
        public string Memo { get; set; }
        List<RecipeDetail> RecipeList = RecipeDataStorage.GetAllList();
        static int CurrentID = 0;

        public DisplayRecipePage(int ID)
        {
            InitializeComponent();
            CurrentID = ID;

            foreach (RecipeDetail detail in RecipeList)
            {
                if (detail.ID == ID)
                {
                    this.Name = detail.Name;
                    if(detail.MaterialAndAmountList != null)
                    {
                        if(detail.MaterialAndAmountList.Count != 0)
                        {
                            this.Material = detail.MaterialAndAmountList[0].Material;
                        }
                        if (detail.MaterialAndAmountList.Count != 0)
                        {
                            this.Amount = detail.MaterialAndAmountList[0].Amount;
                        }
                    }
                    this.Category1 = detail.Category1;
                    this.Category2 = detail.Category2;
                    this.Hour = detail.Hour;
                    this.Minute = detail.Minute;
                    this.HowToMake = detail.HowToMake;
                    this.Memo = detail.Memo;
                }
            }
            this.BindingContext = this;
        }

        private void EditRecipe()
        {
            PageMgr.ViewRegistPage(CurrentID);       /* レシピ登録(編集)画面へ */
        }

        private void GoRecipeListPage()
        {
            PageMgr.ViewRecipeListPage();       /* レシピ一覧画面へ */
        }

        private void DeleteRecipe(object sender, EventArgs e)
        {
            RecipeList.RemoveAt(RecipeDataStorage.GetListIDfromRecipe(CurrentID));
            RecipeDataStorage.SaveAllList(RecipeList);
            PageMgr.ViewRecipeListPage();       /* レシピ一覧画面へ */
        }
    }
}