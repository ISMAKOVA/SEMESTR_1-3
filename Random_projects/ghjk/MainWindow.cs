using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
    protected void OnButton2Clicked(object sender, EventArgs e)
    {
        this.entry1.Text = "";
        this.entry2.Text = "";
        this.entry3.Text = "";
        this.entry4.Text = "";
        this.entry5.Text = "";
        this.entry6.Text = "";
        star1.Visible = false;
        star2.Visible = false;
        star3.Visible = false;
    }

    protected void OnButton1Clicked(object sender, EventArgs e)
    {

        string ta = entry1.Text;
        bool e1 = int.TryParse(ta, out int a);
        if (e1 == false) star1.Visible = true;
        string tb = entry2.Text;
        bool e2 = int.TryParse(tb, out int b);
        if (e2 == false) star2.Visible = true;
        string tc = entry3.Text;
        bool e3 = int.TryParse(tc, out int c);
        if (e3 == false) star3.Visible = true;
        if (a == 0)
        {
            double x = -c / b;
            string x3 = string.Format("{0:f2}", x);
            entry5.Text = x3;
            entry5.Visible = true;
            label5.Visible = true;
        }
        else
        {
            double d = b * b - 4 * a * c;
            string D = string.Format("{0:f2}", d);
            if (d > 0)
            {
                d = Math.Sqrt(d);
                double x1 = (-b - d) / 2 / a;
                double x2 = (-b - d) / 2 / a;
                string X1 = string.Format("{0:f2}", x1);
                string X2 = string.Format("{0:f2}", x2);
                entry5.Text = X1;
                entry6.Text = X2;
                entry4.Text = D;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                entry4.Visible = true;
                entry5.Visible = true;
                entry6.Visible = true;
            }
            else if(d<0)
            {
                entry4.Text = "дискриминант меньше нуля";
                string t = string.Format("{0}+{1}i", a,b);
                entry5.Text = t;
                entry6.Text = t;
            }


        }
    }

   
    public static class MessageBox
    {
        public static void Show(Gtk.Window parent_window, DialogFlags flags, MessageType msgtype, ButtonsType btntype, string msg)
        {
            MessageDialog md = new MessageDialog(parent_window, flags, msgtype, btntype, msg);
            md.Run();
            md.Destroy();
        }
        public static void Show(string msg)
        {
            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, msg);
            md.Run();
            md.Destroy();
        }
    }
    protected void OnButton3Clicked(object sender, EventArgs e)
    {
        star1.Visible = false;
        star2.Visible = false;
        star3.Visible = false;
    }

}
