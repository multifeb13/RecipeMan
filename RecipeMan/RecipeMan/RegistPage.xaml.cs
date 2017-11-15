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
    public partial class RegistPage : ContentPage
    {
        List<RecipeDetail> RecipeList = null;        /* 登録ページで使用するレシピリスト */
        int CurrentID = 0;                           /* 登録ページで使用するレシピID */
        RecipeDetail Temp = new RecipeDetail();      /* 一時保存用レシピ */

        /* 材料、分量の設定 */
        string[] TempMaterialArray = new string[30];        /* 登録ページで一時的に使用する材料配列 */
        string[] TempAmountArray = new string[30];          /* 登録ページで一時的に使用する分量配列 */
        List<MaterialAndAmount> TempMaterialAndAmountList = new List<MaterialAndAmount>();

        /* カテゴリ、調理時間の設定 */
        string[] Category1Array = { "選択なし", "和風", "洋風", "中華" };
        string[] Category2Array = { "選択なし", "主食", "副菜", "汁物" };
        int[] HourArray = new int[21];
        int[] MinuteArray = new int[60];
        
        public RegistPage(List<RecipeDetail> List, int ID)
        {
            InitializeComponent();

            RecipeList = List;  /* レシピリストの複製 */
            CurrentID = ID;     /* IDの複製 */
            RecipeDetail Recipe = RecipeDataStorage.GetSelectRecipeData(ID);    /* 新規登録／編集するレシピ詳細 */

            /* 調理時間の値設定 */
            foreach (var i in Enumerable.Range(0, 21))
            {
                Hour.Items.Add(i.ToString());
                HourArray[i] = i;
            }
            foreach (var i in Enumerable.Range(0, 60))
            {
                Minute.Items.Add(i.ToString());
                MinuteArray[i] = i;
            }

            /* 材料追加ページから遷移した場合のデータ反映 */
            if (RecipeDataStorage.GetTempRecipe() != null)
            {
                Temp = RecipeDataStorage.GetTempRecipe();
                Recipe = Temp;
                RecipeDataStorage.ClearTempRecipe();
            }

            /* 既に情報がある場合（新規登録時以外）のデータ反映 */
            if (Recipe != null)
            {
                int i = 0;
                TempMaterialAndAmountList = Recipe.MaterialAndAmountList;
                
                Material1.Text = TempMaterialAndAmountList[0].Material;
                Material2.Text = TempMaterialAndAmountList[1].Material;
                Material3.Text = TempMaterialAndAmountList[2].Material;

                Amount1.Text = TempMaterialAndAmountList[0].Amount;
                Amount2.Text = TempMaterialAndAmountList[1].Amount;
                Amount3.Text = TempMaterialAndAmountList[2].Amount;

                for (i = 0; i < Category1Array.Length; i++)
                {
                    if (Category1Array[i] == Recipe.Category1)
                    {
                        Category1.SelectedIndex = i;
                        break;
                    }
                }
                for (i = 0; i < Category2Array.Length; i++)
                {
                    if (Category2Array[i] == Recipe.Category2)
                    {
                        Category2.SelectedIndex = i;
                        break;
                    }
                }
                for (i = 0; i < HourArray.Length; i++)
                {
                    if (HourArray[i] == Recipe.Hour)
                    {
                        Hour.SelectedIndex = i;
                        break;
                    }
                }
                for (i = 0; i < MinuteArray.Length; i++)
                {
                    if (MinuteArray[i] == Recipe.Minute)
                    {
                        Minute.SelectedIndex = i;
                        break;
                    }
                }
                Name.Text = Recipe.Name;
                HowToMake.Text = Recipe.HowToMake;
                Memo.Text = Recipe.Memo;
            }
            else
            {
                Temp.ID = CurrentID;
            }

            /* 登録ボタン押下 */
            RegistBtn.Clicked += (sender, e) =>
            {
                if ((Temp.Name == string.Empty || Temp.Name == null) && (Temp.HowToMake == string.Empty || Temp.HowToMake == null))
                {
                    DisplayAlert("以下を入力してください。", "料理名, 作り方", "OK");
                }
                else if (Temp.Name == string.Empty || Temp.Name == null)
                {
                    DisplayAlert("以下を入力してください。", "料理名", "OK");
                }
                else if (Temp.HowToMake == string.Empty || Temp.HowToMake == null)
                {
                    DisplayAlert("以下を入力してください。", "作り方", "OK");
                }
                else
                {
                    RegistRecipe();
                }
            };
            /* 戻るボタン押下 */
            GoRecipeListPageBtn.Clicked += async (s, e) =>
            {
                var result = await DisplayAlert("確認", "編集中のデータは破棄されます。" + "本当にレシピ一覧へ戻りますか？", "OK", "キャンセル");
                if (result)
                {
                    PageMgr.ViewRecipeListPage();
                }
            };
            /* HOMEボタン押下 */
            BackHomeBtn.Clicked += async (s, e) =>
            {
                var result = await DisplayAlert("確認", "編集中のデータは破棄されます。" + "本当にHOMEへ戻りますか？", "OK", "キャンセル");
                if (result)
                {
                    PageMgr.ViewMainPage();
                }
            };
        }

        /* 料理名 */
        private void Name_PropertyChanged(object sender, System.EventArgs e)
        {
            if(Name.Text != null)
            {
                Temp.Name = Name.Text;
            }
        }

        /* 材料 */
        private void Material1_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material1.Text != null)
            {
                TempMaterialArray[0] = Material1.Text;
            }
        }
        private void Material2_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material2.Text != null)
            {
                TempMaterialArray[1] = Material2.Text;
            }
        }
        private void Material3_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material3.Text != null)
            {
                TempMaterialArray[2] = Material3.Text;
            }
        }

        /* 分量 */
        private void Amount1_PropertyChanged(object sender, System.EventArgs e)
        {
            if(Amount1.Text != null)
            {
                TempAmountArray[0] = Amount1.Text;
            }
        }
        private void Amount2_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount2.Text != null)
            {
                TempAmountArray[1] = Amount2.Text;
            }
        }
        private void Amount3_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount3.Text != null)
            {
                TempAmountArray[2] = Amount3.Text;
            }
        }

        /* カテゴリ */
        private void Category1_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var SelectItem = (Picker)sender;
            if (SelectItem.SelectedIndex != -1)
            {
                Temp.Category1 = SelectItem.Items[SelectItem.SelectedIndex];
            }
        }
        private void Category2_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var SelectItem = (Picker)sender;
            if (SelectItem.SelectedIndex != -1)
            {
                Temp.Category2 = SelectItem.Items[SelectItem.SelectedIndex];
            }
        }

        /* 調理時間 */
        private void Hour_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var SelectItem = (Picker)sender;
            if (SelectItem.SelectedIndex != -1)
            {
                Temp.Hour = int.Parse(SelectItem.Items[SelectItem.SelectedIndex]);
            }
        }
        private void Minute_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var SelectItem = (Picker)sender;
            if (SelectItem.SelectedIndex != -1)
            {
                Temp.Minute = int.Parse(SelectItem.Items[SelectItem.SelectedIndex]);
            }
        }

        /* 作り方 */
        private void HowToMake_PropertyChanged(object sender, System.EventArgs e)
        {
            if(HowToMake.Text != null)
            {
                Temp.HowToMake = HowToMake.Text;
            }
        }

        /* メモ */
        private void Memo_PropertyChanged(object sender, System.EventArgs e)
        {
            if(Memo.Text != null)
            {
                Temp.Memo = Memo.Text;
            }
        }

        private void AddMaterial(object sender, System.EventArgs e)
        {
            /* 材料、分量の入力追加画面へ遷移 */
            if (TempMaterialArray[0] == string.Empty || TempMaterialArray[0] == null)
            {
                DisplayAlert("", "材料を入力してください。", "OK");
            }
            else
            {
                MakeMateriaAndAmountList();
                Temp.MaterialAndAmountList = TempMaterialAndAmountList;

                RecipeDataStorage.SetTempRecipe(Temp);
                PageMgr.ViewMaterialPage(CurrentID);
            }
        }

        private void MakeMateriaAndAmountList()
        {
            TempMaterialAndAmountList.Clear();

            for (int i = 0; i < 30; i++)
            {
                MaterialAndAmount TempMaterialAndAmount = new MaterialAndAmount
                {
                    Material = TempMaterialArray[i],
                    Amount = TempAmountArray[i]
                };   /* 材料と分量を補完する箱 */
                
                TempMaterialAndAmountList.Add(TempMaterialAndAmount);
            }
        }

        private void RegistRecipe()
        {
            //Temp.ID = CurrentID;
            MakeMateriaAndAmountList();
            Temp.MaterialAndAmountList = TempMaterialAndAmountList;
            TempMaterialAndAmountList.Clear();

            if (CurrentID == RecipeDataStorage.GetNewRecipeListID())
            {
                /* 新規登録 */
                RecipeList.Add(Temp);
            }
            else
            {
                /* 編集 */
                RecipeList.RemoveAt(CurrentID);
                RecipeList.Insert(CurrentID, Temp);
            }
            RecipeDataStorage.SaveAllList(RecipeList);
            PageMgr.ViewRecipeListPage();                 /* レシピ一覧へ */
        }
    }
}