using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LanguageTranslatorApplication {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
        }

        private void butTranslate_Click(object sender, EventArgs e) {
            string assignText = "could not translate";
            if (optEnglishToGerman.Checked) {
                string result =
                    LanguageTranslator.Translator.TranslateHello(
                    LanguageTranslator.Translator.EnglishToGerman,
                    txtToTranslate.Text);
                if (result.Length > 0) {
                    assignText = result;
                }
            }
            else if (optFrenchToGerman.Checked) {
                string result =
                    LanguageTranslator.Translator.TranslateHello(
                    LanguageTranslator.Translator.FrenchToGerman,
                    txtToTranslate.Text);
                if (result.Length > 0) {
                    assignText = result;
                }
            }
            txtTranslated.Text = assignText;
        }
    }
}