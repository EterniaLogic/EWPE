using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Editor;
using UrielGuy.SyntaxHighlightingTextBox;
using System.Diagnostics;

namespace Editor
{
    public partial class cram : Form
    {
        public cram()
        {
            InitializeComponent();
            zLoad();
            
        }


        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.DefaultExt = "All files (*.*)|*.*";
            openDlg.Filter = "PHP files (*.php, *.php3, *.php4, *.php5)|*.php|Html files (*.html, *.htm)|*.html|Javascript (*.js)|*.js|Css (*.css)|*.css|Active Server Page (*.asp)|*.asp|Active Server Page.Net (*.aspx)|*.aspx|All files (*.*)|*.*";
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
            openDlg.FileName.Length > 0)
            {
                richText.LoadFile(openDlg.FileName, RichTextBoxStreamType.PlainText);
                richText.Modified = false;
                System.Windows.Forms.Form.ActiveForm.Text = openDlg.FileName + " - Extreme WebPage Editor";
                name2.Text = openDlg.FileName;

                modified.Text = "Not Modified";
                star.Text = "";
                modified.ForeColor = System.Drawing.Color.Lime;
                if (openDlg.FileName.EndsWith(".html")) { createVisualTab(); } else { delVisualTab(); }
                if (openDlg.FileName.EndsWith(".htm")) { createVisualTab(); } else{delVisualTab(); }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Checks if the file exists
            bool file;
            file = System.IO.File.Exists(name2.Text);

            if (file == true)
            {
                richText.SaveFile(name2.Text, RichTextBoxStreamType.PlainText);
                richText.Modified = false;
                modified.Text = "Not Modified";
                star.Text = "";
                modified.ForeColor = System.Drawing.Color.Lime;
            }
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PHP files (*.php, *.php3, *.php4, *.php5)|*.php|Html files (*.html, *.htm)|*.html|Javascript (*.js)|*.js|Css (*.css)|*.css|Active Server Page (*.asp)|*.asp|Active Server Page.Net (*.aspx)|*.aspx|All files (*.*)|*.*";
                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    richText.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
                    richText.Modified = false;
                    name2.Text = saveFile.FileName;
                    System.Windows.Forms.Form.ActiveForm.Text = saveFile.FileName + " - Extreme WebPage Editor";
                    star.Text = "";
                    modified.Text = "Not Modified";
                    modified.ForeColor = System.Drawing.Color.Lime;
                    if (saveFile.FileName.EndsWith(".html")) { createVisualTab(); } else { delVisualTab(); }
                    if (saveFile.FileName.EndsWith(".htm")) { createVisualTab(); } else { delVisualTab(); }

                }
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            //SaveAs
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PHP files (*.php, *.php3, *.php4, *.php5)|*.php|Html files (*.html, *.htm)|*.html|Javascript (*.js)|*.js|Css (*.css)|*.css|Active Server Page (*.asp)|*.asp|Active Server Page.Net (*.aspx)|*.aspx|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richText.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
                richText.Modified = false;
                name2.Text = saveFile.FileName;
                System.Windows.Forms.Form.ActiveForm.Text = saveFile.FileName + " - Extreme WebPage Editor";
                modified.Text = "Not Modified";
                star.Text = "";

                modified.ForeColor = System.Drawing.Color.Lime;
                if (saveFile.FileName.EndsWith(".html")) { createVisualTab(); } else { delVisualTab(); }
                if (saveFile.FileName.EndsWith(".htm")) { createVisualTab(); } else { delVisualTab(); }
            }
        }

        private void New_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Form.ActiveForm.Text = "[New] - Extreme WebPage Editor";
            richText.Text = @"<html>
<head>
<title>
New Document
</title>
</head>
<body>

</body>
</html>";
            richText.Focus();
            name2.Text = "[New]";


            richText.Modified = false;
            modified.Text = "Not Modified";
            modified.ForeColor = System.Drawing.Color.Lime;
            star.Text = "";
        }

        private void Opacity_30_Click(object sender, EventArgs e)
        {
            Opacity = .30;
        }

        private void Opacity_50_Click(object sender, EventArgs e)
        {
            Opacity = .50;
        }

        private void Opacity_70_Click(object sender, EventArgs e)
        {
            Opacity = .70;
        }

        private void Opacity_80_Click(object sender, EventArgs e)
        {
            Opacity = .80;
        }

        private void Opacity_90_Click(object sender, EventArgs e)
        {
            Opacity = .90;
        }

        private void Opacity_100_Click(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cram.ActiveForm.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutview.Show(); aboutview.Top = 0; aboutview.Left = 0; wsg.Hide();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            richText.Find(find.Text);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            time.Text = DateTime.Now.ToShortTimeString();
        }

        private void find_Click(object sender, EventArgs e)
        {
            if (find.Text == "[ Enter your search query here ]") { find.Text = ""; }
        }

        private void textAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<textarea></textarea>";
        }

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += @"<form action=index.php method=post>
                </form>";
        }

        private void checkBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input name=\"checkbox1\" type=\"checkbox\" />Checkbox1";
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += @"<select>
<option selected=true>Select Option</option>
</select>";
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += @"<table>
<tr>
<td>

</td>
</tr>
</table>";
        }

        private void horizontalRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<hr />";
        }

        private void divToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<div style=\"height:300;width:300;\"></div>";
        }

        private void iframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<iframe src=\"index.html\" ></iframe>";
        }

        private void spanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<span></span>";
        }

        private void framesetFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += @"<frameset cols =50%,50%>
<frame src=file />
<frame src =file />
</frameset>";
        }

        private void fieldsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<fieldset></fieldset>";
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<a href=\"\"></a>";
        }

        private void imgimageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<img src=\"imagesource.png\" />";
        }

        private void legendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<legend></legend>";
        }

        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input type=\"button\" value=\"button\" />";
        }

        private void submitButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input type=\"submit\" value=\"submit\" />";
        }

        private void resetButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input type=\"reset\" value=\"reset\" />";
        }

        private void radioButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input type=\"radio\" value=\"radio\" />";
        }

        private void hiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input type=\"hidden\" name=\"hidden\" value=\"\" />";
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input type=\"password\" />";
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input type=\"file\" />";
        }

        private void backgroundattachmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "background-attachment:none;";
        }

        private void backgroundimageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "background-image:url(images/sample.gif);";
        }

        private void backgroundcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "background-color:red;";
        }

        private void backgroundpositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "background-position:top left;";
        }

        private void backgroundrepeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "background-repeat:repeat;";
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "color:red;";
        }

        private void leftToRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "direction:ltr;";
        }

        private void rightToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "direction:rtl";
        }

        private void lineheightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "line-height:normal;";
        }

        private void letterspacingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "letter-spacing:normal;";
        }

        private void textalignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "text-align:left;";
        }

        private void textdecorationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "text-decoration:none;";
        }

        private void textindentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "text-indent:0px;";
        }

        private void textshadowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "text-shadow:none;";
        }

        private void texttransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "text-transform:none;";
        }

        private void unicodebidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "unicode-bidi:normal;";
        }

        private void whitespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "white-space:normal;";
        }

        private void wordspacingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "white-spacing:normal;";
        }

        private void borderbottomcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-bottom-color:red;";
        }

        private void borderbottomstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-bottom-style:;";
        }

        private void borderbottomwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-bottom-width:thin;";
        }
        //
        private void bordertopcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-top-color:red;";
        }

        private void bordertopstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-top-style:;";
        }

        private void bordertopwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-top-width:thin;";
        }
        //
        private void borderleftcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-left-color:red;";
        }

        private void borderleftstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-left-style:;";
        }

        private void borderleftwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-left-width:thin;";
        }
        //
        private void borderrightcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-right-color:red;";
        }

        private void borderrightstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-right-style:;";
        }

        private void borderrightwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-right-width:thin;";
        }

        private void borderwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-width:thin;";
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "color:red;";
        }

        private void cursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "cursor:default;";
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "display:none;";
        }

        private void floatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "float:left;";
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "position:static;";
        }

        private void visibilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "visibility:visible";
        }

        private void heightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "height:auto;";
        }

        private void lineheightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "line-height:normal;";
        }

        private void maxheightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "max-height:none;";
        }

        private void maxwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "max-width:none;";
        }

        private void minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "min-height:0px;";
        }

        private void minwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "min-width:0px;";
        }

        private void widthToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "width:auto;";
        }

        private void fontfamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-family:;";
        }

        private void fontsizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-size:8px;";
        }

        private void fontsizeadjustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-size-adjust:none;";
        }

        private void fontstretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-stretch:normal;";
        }

        private void normalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-style:normal;";
        }

        private void itallicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-style:italic;";
        }

        private void obliqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-style:oblique;";
        }

        private void normalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-variant:normal;";
        }

        private void smallcapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-variant:small-caps;";
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-weight:normal;";
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-weight:bold;";
        }

        private void bolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "font-weight:bolder;";
        }

        private void counterincrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "counter-increment:none;";
        }

        private void counterresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "counter-reset:none;";
        }

        private void quotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "quotes:none;";
        }

        private void liststyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "list-style-image:none;";
        }

        private void liststyleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "list-style-position:inner;";
        }

        private void liststyleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "list-style-type:none;";
        }

        private void margintopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "margin-top:auto;";
        }

        private void marginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "margin-bottom:auto;";
        }

        private void marginleftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "margin-left:auto;";
        }

        private void marginrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "margin-right:auto;";
        }

        private void paddingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "padding-top:0px;";
        }

        private void paddingbottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "padding-bottom:0px;";
        }

        private void paddingleftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "padding-left:0px;";
        }

        private void paddingrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "padding-right:0px;";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Paste();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Copy();
        }

        private void toolStripMenuItem190_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "bottom:0px;";
        }

        private void toolStripMenuItem191_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "top:0px;";
        }

        private void toolStripMenuItem192_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "left:0px;";
        }

        private void toolStripMenuItem193_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "right:0px;";
        }

        private void toolStripMenuItem194_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "overflow:scroll;";
        }

        private void toolStripMenuItem196_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "z-index:1;";
        }

        private void toolStripMenuItem197_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "clip:auto;";
        }

        private void toolStripMenuItem200_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-collapse:collapse;";
        }

        private void toolStripMenuItem201_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "border-collapse:separate;";
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "caption-side:top;";
        }

        private void bottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "caption-side:bottom;";
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "caption-side:left;";
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "caption-side:right;";
        }

        private void visibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "overflow:visible;";
        }

        private void hiddenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richText.SelectedText += "overflow:hidden;";
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "overflow:auto;";
        }

        private void toolStripMenuItem205_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "empty-cells:show;";
        }

        private void toolStripMenuItem206_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "empty-cells:hide;";
        }

        private void autoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "table-layout:auto;";
        }

        private void fixedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "table-layout:fixed;";
        }

        private void toolStripMenuItem209_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":active";
        }

        private void toolStripMenuItem210_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":focus";
        }

        private void toolStripMenuItem211_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":hover";
        }

        private void toolStripMenuItem212_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":link";
        }

        private void toolStripMenuItem213_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":visited";
        }

        private void toolStripMenuItem214_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":first-child";
        }

        private void toolStripMenuItem215_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":lang";
        }

        private void toolStripMenuItem217_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":first-letter";
        }

        private void toolStripMenuItem218_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":first-line";
        }

        private void toolStripMenuItem219_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":before";
        }

        private void toolStripMenuItem220_Click(object sender, EventArgs e)
        {
            richText.SelectedText += ":after";
        }

        private void baselineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "vertical-align:baseline;";
        }

        private void subToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "vertical-align:sub;";
        }

        private void superToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "vertical-align:super;";
        }

        private void topToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "vertical-align:top;";
        }

        private void texttopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "vertical-align:text-top;";
        }

        private void middleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "vertical-align:middle;";
        }

        private void bottomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "vertical-align:bottom;";
        }

        private void textbottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "vertical-align:text-bottom;";
        }

        private void staticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "position:static;";
        }

        private void relativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "position:relative;";
        }

        private void absoluteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "position:absolute;";
        }

        private void fixedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "position:fixed;";
        }

        private void scriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<script></script>";
        }

        private void javascriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<script type=\"text/javascript\"></script>";
        }

        private void vbscriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<script type=\"text/vbscript\"></script>";
        }

        private void headToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<head></head>";
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<style type=\"text/css\">body {}</style>";
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<title></title>";
        }

        private void linkstylesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<link rel=\"stylesheet\" href=\"stylesheet.css\" />";
        }

        private void linkAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<link rel=\"shortcut icon\" href=\"adressbar.gif\" type=\"image/x-icon\">";
        }

        private void bodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<body></body>";
        }

        private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<html></html>";
        }

        private void bboldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<b></b>";
        }

        private void emitalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<em></em>";
        }

        private void codeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<code></code>";
        }

        private void supsuperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<sup></sup>";
        }

        private void subToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<sub></sub>";
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += "<input type=\"text\" />";
        }
        public int CurrentTagStart = 0;
        public string intellisenseBuffer = "";
        public bool PassInputToTextbox = true;
        private void rtbInput_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Oemcomma && e.Shift == true)
            {
                CurrentTagStart = richText.SelectionStart;
                Point p = richText.GetPositionFromCharIndex(richText.SelectionStart);
                p.Y += (int)richText.Font.GetHeight() * 2;
                Console.WriteLine((int)richText.Font.GetHeight());
                HTML.Location = p;
                HTML.Show();
                ActiveControl = HTML;
            }
            if (e.KeyCode == Keys.D4 && e.Shift == true)
            {
                CurrentTagStart = richText.SelectionStart;
                Point p = richText.GetPositionFromCharIndex(richText.SelectionStart);
                p.Y += (int)richText.Font.GetHeight() * 2;
                Console.WriteLine((int)richText.Font.GetHeight());
                useDollar.Location = p;
                useDollar.Show();
                ActiveControl = useDollar;
            }
            if (e.KeyCode != Keys.D4 && e.Shift == false && e.KeyCode != Keys.Oemcomma && e.Shift == false)
            {
                intellisenseBuffer = "";
                HTML.Hide();
                useDollar.Hide();
                jsDoc.Hide();
                jsWin.Hide();
                jsWinFrames.Hide();
                jsWinHistory.Hide();
                jsWinLocation.Hide();
                jsWinNavigator.Hide();
                jsWinScreen.Hide();
                PHP_mysql.Hide();
            }



            if (e.KeyCode == Keys.Back)
            {
                intellisenseBuffer = "";
                HTML.Hide();
                useDollar.Hide();
                jsDoc.Hide();
                jsWin.Hide();
                jsWinFrames.Hide();
                jsWinHistory.Hide();
                jsWinLocation.Hide();
                jsWinNavigator.Hide();
                jsWinScreen.Hide();
                PHP_mysql.Hide();
            }
        }

        private void lbIntelli_KeyUp(object sender, KeyEventArgs e) { }

        private void lbIntelli_KeyPress(object sender, KeyPressEventArgs e)
        {
            richText.SelectedText = e.KeyChar.ToString();
        }

        private void HTML_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += HTML.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void HTML_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += HTML.SelectedItem;
                HTML.Hide(); richText.Focus();
            }
        }
        private void useDollar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += useDollar.SelectedItem;
                useDollar.Hide(); richText.Focus();
            }
        }

        private void webSiteGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wsg.Top = 0; wsg.Left = 0; wsg.Show(); aboutview.Hide();
        }

        private void useDollar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += useDollar.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void richText_Click(object sender, EventArgs e)
        {
            intellisenseBuffer = "";
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            wsg.Hide(); aboutview.Hide();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectAll();
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Select(richText.SelectionStart, 0);
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
        private void jsDoc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += HTML.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void jsDoc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += jsDoc.SelectedItem;
                jsDoc.Hide();
            }
        }
        private void jsWin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += jsWin.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void jsWin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += jsWin.SelectedItem;
                jsWin.Hide();
            }
        }
        private void jsWinNavigator_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += jsWinNavigator.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void jsWinNavigator_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += jsWinNavigator.SelectedItem;
                jsWinNavigator.Hide();
            }
        }
        private void jsWinFrames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += jsWinFrames.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void jsWinFrames_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += jsWinFrames.SelectedItem;
                jsWinFrames.Hide();
            }
        }
        private void jsWinHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += jsWinHistory.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void jsWinHistory_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += jsWinHistory.SelectedItem;
                jsWinHistory.Hide();
            }
        }
        private void jsWinLocation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += jsWinLocation.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void jsWinLocation_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += jsWinLocation.SelectedItem;
                jsWinLocation.Hide();
            }
        }
        private void jsWinScreen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += jsWinScreen.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void jsWinScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += jsWinScreen.SelectedItem;
                jsWinScreen.Hide();
            }
        }
        private void PHP_mysql_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            intellisenseBuffer = "";
            richText.SelectedText += PHP_mysql.SelectedItem;
            HTML.Hide();
            useDollar.Hide();
            jsDoc.Hide();
            jsWin.Hide();
            jsWinFrames.Hide();
            jsWinHistory.Hide();
            jsWinLocation.Hide();
            jsWinNavigator.Hide();
            jsWinScreen.Hide();
            PHP_mysql.Hide();
        }

        private void PHP_mysql_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                intellisenseBuffer = "";
                richText.SelectedText += PHP_mysql.SelectedItem;
                PHP_mysql.Hide();
            }
        }


        private void OPEN(object sender, EventArgs e)
        {
            if (this.Text != "")
            {
                richText.LoadFile(this.Text, RichTextBoxStreamType.PlainText);
                System.Windows.Forms.Form.ActiveForm.Text = this.Text + " - Extreme WebPage Editor";
                name2.Text = this.Text;

            }
        }
        private void onModify(object sender, EventArgs e)
        {
            modified.Text = "Modified";
            System.Windows.Forms.Form.ActiveForm.Text = name2.Text + "* - Extreme WebPage Editor";
            modified.ForeColor = System.Drawing.Color.Cyan;
            star.Text = "*";
        }

        private void normalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richText.ZoomFactor = 1;
        }

        private void toolStripMenuItem100_Click(object sender, EventArgs e)
        {
            richText.ZoomFactor = 2;
        }

        private void toolStripMenuItem222_Click(object sender, EventArgs e)
        {
            richText.ZoomFactor = 3;
        }

        private void toolStripMenuItem223_Click(object sender, EventArgs e)
        {
            richText.ZoomFactor = 4;
        }
        private void zLoad()
        {
            richText.FilterAutoComplete = false;
            richText.Seperators.Add(' ');
            richText.Seperators.Add('\r');
            richText.Seperators.Add('\n');
            richText.Seperators.Add(',');
            richText.Seperators.Add('.');
            richText.Seperators.Add('-');
            richText.Seperators.Add('+');
            richText.HighlightDescriptors.Add(new HighlightDescriptor("<?", Color.DarkOrange, null, DescriptorType.Word, DescriptorRecognition.StartsWith, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor("?>", Color.DarkOrange, null, DescriptorType.Word, DescriptorRecognition.Contains, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor("<", Color.DarkSlateBlue, null, DescriptorType.Word, DescriptorRecognition.StartsWith, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor(">", Color.DarkSlateBlue, null, DescriptorType.Word, DescriptorRecognition.Contains, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor("'", "'", Color.DarkSeaGreen, null, DescriptorType.ToCloseToken, DescriptorRecognition.StartsWith, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor("$", Color.ForestGreen, null, DescriptorType.Word, DescriptorRecognition.StartsWith, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor("new", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.StartsWith, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor("false", Color.DarkSeaGreen, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor("true", Color.DarkSeaGreen, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            richText.HighlightDescriptors.Add(new HighlightDescriptor("return", Color.DarkSeaGreen, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
        }

        private void fTPClientProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"winscp/WinSCP.exe");
        }

        private void liveswifFreeFlashMakerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"extras/ls/ls.exe");
        }

        private void liveswiferscomLiveswifForumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"extras/ls/liveswifers.com.URL");
        }

        private void liveswifswfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.SelectedText += @"<!-- Liveswif Code Start -->
<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0' width='400' height='400'>
    <param name='movie' value='Untitled.swf'>
    <param name='quality' value='high'>
    <embed src='Untitled.swf' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width='400' height='400'>
    </embed>
</object>
<!-- Liveswif Code End -->";
        }



        /// <summary>
        /// Visual Tab (wysiwyg) Editor
        /// </summary>
        private void createVisualTab() 
        {
            tabControl1.TabPages.Add(VisualEdit);
        }
        private void delVisualTab()
        {
            tabControl1.TabPages.Remove(VisualEdit);
        }



       
    }
}