using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Core
{
    public class WebUtility
    {
        public static void SetControlValue(WebControl control, object value)
        {
            if (control != null)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = value.ToStringValue();
                }
                else if (control is CheckBox)
                {
                    if (value.ToBooleanValue().HasValue)
                    {
                        ((CheckBox)control).Checked = value.ToBooleanValue().Value;
                    }
                }
                else if (control is RadioButton)
                {
                    if (value.ToBooleanValue().HasValue)
                    {
                        ((RadioButton)control).Checked = value.ToBooleanValue().Value;
                    }
                }
                else if (control is DropDownList)
                {
                    if (value is int)
                    {
                        ((DropDownList)control).SelectedIndex = value.ToIntegerValue().Value;

                        return;
                    }

                    ((DropDownList)control).SelectedValue = value.ToStringValue();
                }
                else if (control is Label)
                {
                    ((Label)control).Text = value.ToStringValue();
                }
                else if (control is Button)
                {
                    ((Button)control).Text = value.ToStringValue();
                }
                else if (control is LinkButton)
                {
                    ((LinkButton)control).Text = value.ToStringValue();
                }
                else if (control is HyperLink)
                {
                    ((HyperLink)control).Text = value.ToStringValue();
                }
                else if (control is Calendar)
                {
                    if (value.ToDateTimeValue().HasValue)
                    {
                        ((Calendar)control).SelectedDate = value.ToDateTimeValue().Value;
                    }
                }
            }
        }

        public static object GetControlValue(WebControl control)
        {
            if (control != null)
            {
                if (control is TextBox)
                {
                    return ((TextBox)control).Text.Trim();
                }
                if (control is CheckBox)
                {
                    return ((CheckBox)control).Checked;
                }
                if (control is RadioButton)
                {
                    return ((RadioButton)control).Checked;
                }
                if (control is ListControl)
                {
                    return ((ListControl)control).SelectedValue;
                }
                if (control is Calendar)
                {
                    return ((Calendar)control).SelectedDate;
                }
                if (control is Label)
                {
                    return ((Label)control).Text;
                }
                if (control is Button)
                {
                    return ((Button)control).Text;
                }
                if (control is HyperLink)
                {
                    return ((HyperLink)control).Text;
                }
            }
            return null;
        }

        public static void ResetControlValue(WebControl control)
        {
            if (control != null)
            {
                if (control.Controls.Count == 0)
                {
                    if (control is WebControl)
                    {
                        if (control is TextBox)
                        {
                            ((TextBox)control).Text = string.Empty;
                        }
                        else if (control is CheckBox)
                        {
                            ((CheckBox)control).Checked = false;
                        }
                        else if (control is RadioButton)
                        {
                            ((RadioButton)control).Checked = false;
                        }
                        else if (control is ListControl)
                        {
                            ((ListControl)control).SelectedIndex = -1;
                        }
                        else if (control is Calendar)
                        {
                            ((Calendar)control).SelectedDate = DateTime.Now;
                        }
                    }
                }
            }
        }

        public static void ResetControlValue(ControlCollection controls)
        {
            if ((controls != null) && (controls.Count != 0))
            {
                foreach (Control control in controls)
                {
                    ResetControlValue(control as WebControl);
                }
            }
        }

        public static void FillCombo(DropDownList control, IDictionary<Guid, string> data)
        {
            if (control != null && data != null)
            {
                control.DataSource = data;
                control.DataTextField = "Value";
                control.DataValueField = "Key";
                control.DataBind();
            }
        }

        public static void FillCombo(DropDownList control, IDictionary<Guid, string> data, ListItem firsItem)
        {
            if (control != null && data != null)
            {
                control.DataSource = data;
                control.DataTextField = "Value";
                control.DataValueField = "Key";
                control.DataBind();

                control.Items.Insert(0, firsItem);
            }
        }

        public static void FillCombo<T, T1>(DropDownList control, IDictionary<T, T1> data)
        {
            if (control != null && data != null)
            {
                control.DataSource = data;
                control.DataTextField = "Value";
                control.DataValueField = "Key";
                control.DataBind();
            }
        }       

        public static void FillCombo<T,T1>(DropDownList control, IDictionary<T, T1> data, ListItem firsItem)
        {
            if (control != null && data != null)
            {
                control.DataSource = data;
                control.DataTextField = "Value";
                control.DataValueField = "Key";
                control.DataBind();

                control.Items.Insert(0, firsItem);
            }
        }       
    }
}
