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
    public partial class MaterialPage : ContentPage
    {
        RecipeDetail TempRecipe = null;                     /* 入力中の一時保管しているレシピ情報 */
        string[] TempMaterialArray = new string[30];        /* 追加材料入力画面にて一時的に使用する材料配列 */
        string[] TempAmountArray = new string[30];          /* 追加材料入力画面にて一時的に使用する分量配列 */
        List<MaterialAndAmount> TempMaterialAndAmountList = new List<MaterialAndAmount>();       /* 追加材料入力画面にて一時的に使用する材料リスト */
        int CurrentID = 0;

        public MaterialPage(int ID)
        {
            InitializeComponent();

            CurrentID = ID;
            TempRecipe = RecipeDataStorage.GetTempRecipe();

            /* 入力済みデータを反映 */
            if (TempRecipe.MaterialAndAmountList.Count != 0)
            {
                /* 材料 */
                if (TempRecipe.MaterialAndAmountList[0].Material != null)
                {
                    Material1.Text = TempRecipe.MaterialAndAmountList[0].Material;
                }
                if (TempRecipe.MaterialAndAmountList[1].Material != null)
                {
                    Material2.Text = TempRecipe.MaterialAndAmountList[1].Material;
                }
                if (TempRecipe.MaterialAndAmountList[2].Material != null)
                {
                    Material3.Text = TempRecipe.MaterialAndAmountList[2].Material;
                }

                /* 分量 */
                if (TempRecipe.MaterialAndAmountList[0].Amount != null)
                {
                    Amount1.Text = TempRecipe.MaterialAndAmountList[0].Amount;
                }
                if (TempRecipe.MaterialAndAmountList[1].Amount != null)
                {
                    Amount2.Text = TempRecipe.MaterialAndAmountList[1].Amount;
                }
                if (TempRecipe.MaterialAndAmountList[2].Amount != null)
                {
                    Amount3.Text = TempRecipe.MaterialAndAmountList[2].Amount;
                }
            }
        }

        private void GoBackBtn()
        {
            int i = 0;
            TempRecipe.MaterialAndAmountList.Clear();
            for (i = 0; i < 30; i++)
            {
                MaterialAndAmount TempMaterialAndAmount = new MaterialAndAmount
                {
                    Material = TempMaterialArray[i],
                    Amount = TempAmountArray[i]
                };   /* 材料と分量を補完する箱 */

                TempRecipe.MaterialAndAmountList.Add(TempMaterialAndAmount);
            }

            RecipeDataStorage.SetTempRecipe(TempRecipe);
            PageMgr.ViewRegistPage(CurrentID);
        }

        /**** 材料 ****/
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
        private void Material4_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material4.Text != null)
            {
                TempMaterialArray[3] = Material4.Text;
            }
        }
        private void Material5_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material5.Text != null)
            {
                TempMaterialArray[4] = Material5.Text;
            }
        }
        private void Material6_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material6.Text != null)
            {
                TempMaterialArray[5] = Material6.Text;
            }
        }
        private void Material7_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material7.Text != null)
            {
                TempMaterialArray[6] = Material7.Text;
            }
        }
        private void Material8_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material8.Text != null)
            {
                TempMaterialArray[7] = Material8.Text;
            }
        }
        private void Material9_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material9.Text != null)
            {
                TempMaterialArray[8] = Material9.Text;
            }
        }
        private void Material10_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material10.Text != null)
            {
                TempMaterialArray[9] = Material10.Text;
            }
        }
        private void Material11_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material11.Text != null)
            {
                TempMaterialArray[10] = Material11.Text;
            }
        }
        private void Material12_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material12.Text != null)
            {
                TempMaterialArray[11] = Material12.Text;
            }
        }
        private void Material13_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material13.Text != null)
            {
                TempMaterialArray[12] = Material13.Text;
            }
        }
        private void Material14_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material14.Text != null)
            {
                TempMaterialArray[13] = Material14.Text;
            }
        }
        private void Material15_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material15.Text != null)
            {
                TempMaterialArray[14] = Material15.Text;
            }
        }
        private void Material16_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material16.Text != null)
            {
                TempMaterialArray[15] = Material16.Text;
            }
        }
        private void Material17_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material17.Text != null)
            {
                TempMaterialArray[16] = Material17.Text;
            }
        }
        private void Material18_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material18.Text != null)
            {
                TempMaterialArray[17] = Material18.Text;
            }
        }
        private void Material19_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material19.Text != null)
            {
                TempMaterialArray[18] = Material19.Text;
            }
        }
        private void Material20_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material20.Text != null)
            {
                TempMaterialArray[19] = Material20.Text;
            }
        }
        private void Material21_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material21.Text != null)
            {
                TempMaterialArray[20] = Material21.Text;
            }
        }
        private void Material22_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material22.Text != null)
            {
                TempMaterialArray[21] = Material22.Text;
            }
        }
        private void Material23_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material23.Text != null)
            {
                TempMaterialArray[22] = Material23.Text;
            }
        }
        private void Material24_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material24.Text != null)
            {
                TempMaterialArray[23] = Material24.Text;
            }
        }
        private void Material25_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material25.Text != null)
            {
                TempMaterialArray[24] = Material25.Text;
            }
        }
        private void Material26_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material26.Text != null)
            {
                TempMaterialArray[25] = Material26.Text;
            }
        }
        private void Material27_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material27.Text != null)
            {
                TempMaterialArray[26] = Material27.Text;
            }
        }
        private void Material28_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material28.Text != null)
            {
                TempMaterialArray[27] = Material28.Text;
            }
        }
        private void Material29_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material29.Text != null)
            {
                TempMaterialArray[28] = Material29.Text;
            }
        }
        private void Material30_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Material30.Text != null)
            {
                TempMaterialArray[29] = Material30.Text;
            }
        }


        /**** 分量 ****/
        private void Amount1_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount1.Text != null)
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
        private void Amount4_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount4.Text != null)
            {
                TempAmountArray[3] = Amount4.Text;
            }
        }
        private void Amount5_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount5.Text != null)
            {
                TempAmountArray[4] = Amount5.Text;
            }
        }
        private void Amount6_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount6.Text != null)
            {
                TempAmountArray[5] = Amount6.Text;
            }
        }
        private void Amount7_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount7.Text != null)
            {
                TempAmountArray[6] = Amount7.Text;
            }
        }
        private void Amount8_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount8.Text != null)
            {
                TempAmountArray[7] = Amount8.Text;
            }
        }
        private void Amount9_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount9.Text != null)
            {
                TempAmountArray[8] = Amount9.Text;
            }
        }
        private void Amount10_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount10.Text != null)
            {
                TempAmountArray[9] = Amount10.Text;
            }
        }
        private void Amount11_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount11.Text != null)
            {
                TempAmountArray[10] = Amount11.Text;
            }
        }
        private void Amount12_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount12.Text != null)
            {
                TempAmountArray[11] = Amount12.Text;
            }
        }
        private void Amount13_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount13.Text != null)
            {
                TempAmountArray[12] = Amount13.Text;
            }
        }
        private void Amount14_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount14.Text != null)
            {
                TempAmountArray[13] = Amount14.Text;
            }
        }
        private void Amount15_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount15.Text != null)
            {
                TempAmountArray[14] = Amount15.Text;
            }
        }
        private void Amount16_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount16.Text != null)
            {
                TempAmountArray[15] = Amount16.Text;
            }
        }
        private void Amount17_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount17.Text != null)
            {
                TempAmountArray[16] = Amount17.Text;
            }
        }
        private void Amount18_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount18.Text != null)
            {
                TempAmountArray[17] = Amount18.Text;
            }
        }
        private void Amount19_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount19.Text != null)
            {
                TempAmountArray[18] = Amount19.Text;
            }
        }
        private void Amount20_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount20.Text != null)
            {
                TempAmountArray[19] = Amount20.Text;
            }
        }
        private void Amount21_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount21.Text != null)
            {
                TempAmountArray[20] = Amount21.Text;
            }
        }
        private void Amount22_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount22.Text != null)
            {
                TempAmountArray[21] = Amount22.Text;
            }
        }
        private void Amount23_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount23.Text != null)
            {
                TempAmountArray[22] = Amount23.Text;
            }
        }
        private void Amount24_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount24.Text != null)
            {
                TempAmountArray[23] = Amount24.Text;
            }
        }
        private void Amount25_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount25.Text != null)
            {
                TempAmountArray[24] = Amount25.Text;
            }
        }
        private void Amount26_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount26.Text != null)
            {
                TempAmountArray[25] = Amount26.Text;
            }
        }
        private void Amount27_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount27.Text != null)
            {
                TempAmountArray[26] = Amount27.Text;
            }
        }
        private void Amount28_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount28.Text != null)
            {
                TempAmountArray[27] = Amount28.Text;
            }
        }
        private void Amount29_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount29.Text != null)
            {
                TempAmountArray[28] = Amount29.Text;
            }
        }
        private void Amount30_PropertyChanged(object sender, System.EventArgs e)
        {
            if (Amount30.Text != null)
            {
                TempAmountArray[29] = Amount30.Text;
            }
        }
    }
}