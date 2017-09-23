using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BaseLibrary.Object;

namespace BaseLibrary.IniEdit
{
    public class IniEditLoader
    {
        public static Panel LoadIniObject(IniObject ini, int labelWidth = 200, int textboxLength = 250)
        {
            var panel = new Panel();
            panel.AutoScroll = true;
            panel.Text = ini.IniFile;


            var startX = 10;
            var xgap = 5;

            var startY = 10;
            var ygap = 5;


            foreach (var f in ini.GetType().GetFields())
            {
                var attr = f.GetCustomAttribute<IniAttribute>();
                if (f.IsPublic)
                {
                    switch (f.FieldType.Name)
                    {
                        case "UInt64":
                        case "ulong":
                        case "Ulong":
                            {
                                //mac address
                                var l = new Label();
                                l.Text = f.Name;
                                l.TextAlign = ContentAlignment.MiddleRight;
                                l.Location = new Point(startX, startY);
                                l.Width = labelWidth;
                                panel.Controls.Add(l);

                                var t = new TextBox();
                                t.Name = f.Name;
                                t.Text = ((ulong)f.GetValue(ini)).ToString("X12");
                                t.Location = new Point(startX + l.Width + xgap, startY);
                                t.Width = textboxLength;
                                panel.Controls.Add(t);

                                startY += t.Height + ygap;

                                if (attr != null && attr.Mode == IniMode.Readonly)
                                {
                                    t.ReadOnly = true; t.Enabled = false;
                                }
                            }
                            break;

                        case "Int32":
                            {
                                var l = new Label();
                                l.Text = f.Name;
                                l.TextAlign = ContentAlignment.MiddleRight;
                                l.Location = new Point(startX, startY);
                                l.Width = labelWidth;
                                panel.Controls.Add(l);

                                var t = new TextBox();
                                t.Name = f.Name;
                                t.Text = ((int)f.GetValue(ini)).ToString();
                                t.Location = new Point(startX + l.Width + xgap, startY);
                                t.Width = textboxLength;
                                panel.Controls.Add(t);

                                startY += t.Height + ygap;
                                if (attr != null && attr.Mode == IniMode.Readonly)
                                {
                                    t.ReadOnly = true; t.Enabled = false;
                                }
                            }
                            break;

                        case "Boolean":
                            {
                                var c = new CheckBox();
                                c.Text = f.Name;
                                c.Name = f.Name;
                                c.Checked = (bool)f.GetValue(ini);
                                c.Width = labelWidth;
                                c.Location = new Point(startX, startY);
                                panel.Controls.Add(c);

                                startY += c.Height + ygap;
                                if (attr != null && attr.Mode == IniMode.Readonly)
                                {
                                    c.Enabled = false;
                                }
                            }
                            break;

                        case "Single":
                            {
                                var l = new Label();
                                l.Text = f.Name;
                                l.TextAlign = ContentAlignment.MiddleRight;
                                l.Location = new Point(startX, startY);
                                l.Width = labelWidth;
                                panel.Controls.Add(l);

                                var t = new TextBox();
                                t.Name = f.Name;
                                t.Text = ((float)f.GetValue(ini)).ToString("F6");
                                t.Location = new Point(startX + l.Width + xgap, startY);
                                t.Width = textboxLength;
                                panel.Controls.Add(t);

                                startY += t.Height + ygap;
                                if (attr != null && attr.Mode == IniMode.Readonly)
                                {
                                    t.ReadOnly = true; t.Enabled = false;
                                }
                            }
                            break;
                        case "Double":
                            {
                                var l = new Label();
                                l.Text = f.Name; l.TextAlign = ContentAlignment.MiddleRight;
                                l.Location = new Point(startX, startY);
                                l.Width = labelWidth;
                                panel.Controls.Add(l);

                                var t = new TextBox();
                                t.Name = f.Name;
                                t.Text = ((double)f.GetValue(ini)).ToString("F6");
                                t.Location = new Point(startX + l.Width + xgap, startY);
                                t.Width = textboxLength;
                                panel.Controls.Add(t);

                                startY += t.Height + ygap;
                                if (attr != null && attr.Mode == IniMode.Readonly)
                                {
                                    t.ReadOnly = true; t.Enabled = false;
                                }
                            }
                            break;

                        case "String":
                            {
                                var l = new Label();
                                l.Text = f.Name; l.TextAlign = ContentAlignment.MiddleRight;
                                l.Location = new Point(startX, startY);
                                l.Width = labelWidth;
                                panel.Controls.Add(l);

                                var t = new TextBox();
                                t.Name = f.Name;
                                t.Text = (string)f.GetValue(ini);
                                t.Location = new Point(startX + l.Width + xgap, startY);
                                t.Width = textboxLength;
                                panel.Controls.Add(t);

                                startY += t.Height + ygap;
                                if (attr != null && attr.Mode == IniMode.Readonly)
                                {
                                    t.ReadOnly = true; t.Enabled = false;
                                }
                            }
                            break;
                    }
                }
            }


            return panel;
        }

        public static void UpdateIniObject(ref IniObject ini, Panel panel)
        {
            //find field of control by control name
            var fieldsNames = ini.GetType().GetFields().Select(f => f.Name).ToList();

            foreach (Control control in panel.Controls)
            {
                if (fieldsNames.Contains(control.Name))
                {
                    var f = ini.GetType().GetField(control.Name);
                    switch (f.FieldType.Name)
                    {
                        case "UInt64":
                        case "ulong":
                        case "Ulong":
                            {
                                //mac address
                                var c = (TextBox)control;
                                f.SetValue(ini, Convert.ToUInt64(c.Text, 16));
                            }
                            break;

                        case "Int32":
                            {
                                var c = (TextBox)control;
                                f.SetValue(ini, Convert.ToInt32(c.Text));
                            }
                            break;

                        case "Boolean":
                            {
                                var c = (CheckBox)control;
                                f.SetValue(ini, c.Checked);
                            }
                            break;

                        case "Single":
                            {
                                var c = (TextBox)control;
                                f.SetValue(ini, float.Parse(c.Text));
                            }
                            break;

                        case "Double":
                            {
                                var c = (TextBox)control;
                                f.SetValue(ini, double.Parse(c.Text));
                            }
                            break;

                        case "String":
                            {
                                var c = (TextBox)control;
                                f.SetValue(ini, (c.Text));
                            }
                            break;
                    }
                }
            }


            ini.OnReloadEvent();
        }

    }
}