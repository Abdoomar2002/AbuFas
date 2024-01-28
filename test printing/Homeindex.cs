using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_printing
{
    public partial class Home : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        public Home()
        {
            InitializeComponent();
            date.Text = DateTime.Today.ToShortDateString();
            firstPage1.BringToFront();
            right.Width = 300;
            
        }

        private void Print_Click(object sender, EventArgs e)
        {
           // bill1.btn_print(bill1.Width,bill1.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            right.FillColor = Color.FromArgb(180, 0, 0,0);
            top.FillColor = Color.FromArgb(180, 0, 0,0);
            AppDbContext context = new AppDbContext();
            //context.Database.OpenConnection();
            context.Database.EnsureCreated();
           
           
         //   SQLitePCL.ISQLite3Provider provider = new SQLitePCL.ISQLite3Provider();
         
          
          //  MessageBox.Show(context.Bills.ToList().ToString());
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Grambtn_Click(object sender, EventArgs e)
        {
            gramsCount.BringToFront();
            gramsCount.GramsCount_Load(null, null);
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);


        }

        private void billsbtn_Click(object sender, EventArgs e)
        {
            firstPage1.BringToFront();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
        }

        private void btntStatic_Click(object sender, EventArgs e)
        {
            dayStatic1.BringToFront();
            dayStatic1.load(DateTime.Today.Date);
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
           
        }
        private void colorChange(string name) 
        {
            Guna2Button []btns = { btnPayment, btnShopper, billsbtn, Grambtn, btntStatic };
            foreach(Guna2Button btn in  btns) 
            {
                if(btn.Name == name)
                {
                    btn.FillColor = Color.FromArgb(255, 212, 175, 55);
                    
                }else btn.FillColor = Color.FromArgb(0, 212, 175, 55);
            }
        }

        private void firstPage1_Load(object sender, EventArgs e)
        {

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            borrow1.BringToFront();
            borrow1.load();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
        }

        private void btnShopper_Click(object sender, EventArgs e)
        {
            customers1.BringToFront();
            customers1.load();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
/*   
  
    To prevent possible data loss before loading the designer, the following errors must be resolved:   
 
    
  
    5 Errors   
  
  Ignore and Continue   
    Why am I seeing this page?   
 
 
  
 
  
   Method not found: 'Microsoft.Extensions.DependencyInjection.ServiceProvider Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(Microsoft.Extensions.DependencyInjection.IServiceCollection)'.     
 
  
 
  
 
Instances of this error (5)  
 
1.   Hide Call Stack 
 
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.g__BuildServiceProvider|3()
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.b__2(Int64 k)
at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.GetOrAdd(IDbContextOptions options, Boolean providerRequired)
at Microsoft.EntityFrameworkCore.DbContext..ctor(DbContextOptions options)
at Microsoft.EntityFrameworkCore.DbContext..ctor()
at test_printing.AppDbContext..ctor() in D:\AbuFas\AbuFas\test printing\AppDbContext.cs:line 36
at AbuFas.customers..ctor() in D:\AbuFas\AbuFas\test printing\customers.cs:line 16  
 
2.   Hide Call Stack 
 
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.g__BuildServiceProvider|3()
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.b__2(Int64 k)
at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.GetOrAdd(IDbContextOptions options, Boolean providerRequired)
at Microsoft.EntityFrameworkCore.DbContext..ctor(DbContextOptions options)
at Microsoft.EntityFrameworkCore.DbContext..ctor()
at test_printing.AppDbContext..ctor() in D:\AbuFas\AbuFas\test printing\AppDbContext.cs:line 36
at test_printing.bill..ctor() in D:\AbuFas\AbuFas\test printing\bill.cs:line 25
at test_printing.BuySell.InitializeComponent() in D:\AbuFas\AbuFas\test printing\BuySell.Designer.cs:line 37
at test_printing.BuySell..ctor() in D:\AbuFas\AbuFas\test printing\BuySell.cs:line 27  
 
3.   Hide Call Stack 
 
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.g__BuildServiceProvider|3()
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.b__2(Int64 k)
at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.GetOrAdd(IDbContextOptions options, Boolean providerRequired)
at Microsoft.EntityFrameworkCore.DbContext..ctor(DbContextOptions options)
at Microsoft.EntityFrameworkCore.DbContext..ctor()
at test_printing.AppDbContext..ctor() in D:\AbuFas\AbuFas\test printing\AppDbContext.cs:line 36
at test_printing.Archive..ctor() in D:\AbuFas\AbuFas\test printing\Archive.cs:line 32  
 
4.   Hide Call Stack 
 
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.g__BuildServiceProvider|3()
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.b__2(Int64 k)
at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.GetOrAdd(IDbContextOptions options, Boolean providerRequired)
at Microsoft.EntityFrameworkCore.DbContext..ctor(DbContextOptions options)
at Microsoft.EntityFrameworkCore.DbContext..ctor()
at test_printing.AppDbContext..ctor() in D:\AbuFas\AbuFas\test printing\AppDbContext.cs:line 36
at AbuFas.Borrow..ctor() in D:\AbuFas\AbuFas\test printing\Borrow.cs:line 19  
 
5.   Hide Call Stack 
 
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.g__BuildServiceProvider|3()
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.<>c__DisplayClass4_0.b__2(Int64 k)
at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
at Microsoft.EntityFrameworkCore.Internal.ServiceProviderCache.GetOrAdd(IDbContextOptions options, Boolean providerRequired)
at Microsoft.EntityFrameworkCore.DbContext..ctor(DbContextOptions options)
at Microsoft.EntityFrameworkCore.DbContext..ctor()
at test_printing.AppDbContext..ctor() in D:\AbuFas\AbuFas\test printing\AppDbContext.cs:line 36
at AbuFas.GramsCount.GramsCount_Load(Object sender, EventArgs e) in D:\AbuFas\AbuFas\test printing\GramsCount.cs:line 39
at System.Windows.Forms.UserControl.OnLoad(EventArgs e)
at System.Windows.Forms.UserControl.OnCreateControl()
at System.Windows.Forms.Control.CreateControl(Boolean fIgnoreVisible)
at System.Windows.Forms.Control.CreateControl(Boolean fIgnoreVisible)
at System.Windows.Forms.Control.CreateControl()
at System.Windows.Forms.Control.ControlCollection.Add(Control value)
at System.Windows.Forms.Form.ControlCollection.Add(Control value)
at System.Windows.Forms.Design.ControlDesigner.DesignerControlCollection.Add(Control c)  

 
Help with this error  
 
Could not find an associated help topic for this error. Check Windows Forms Design-Time error list   
 

 
Forum posts about this error  
 
Search the MSDN Forums for posts related to this error   
 
 
   

 
 
  
   The variable 'customers1' is either undeclared or was never assigned.     Go to code  
     
 
  
 
  
 
Instances of this error (1)  
 
1.   Abu Fas Homeindex.Designer.cs Line:61 Column:1   Show Call Stack  
 
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.Error(IDesignerSerializationManager manager, String exceptionText, String helpLink)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeExpression(IDesignerSerializationManager manager, String name, CodeExpression expression)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeExpression(IDesignerSerializationManager manager, String name, CodeExpression expression)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeStatement(IDesignerSerializationManager manager, CodeStatement statement)  

 
Help with this error  
 
MSDN Help   
 

 
Forum posts about this error  
 
Search the MSDN Forums for posts related to this error   
 
 
   

 
 
  
   The variable 'firstPage1' is either undeclared or was never assigned.     Go to code  
     
 
  
 
  
 
Instances of this error (1)  
 
1.   Abu Fas Homeindex.Designer.cs Line:62 Column:1   Show Call Stack  
 
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.Error(IDesignerSerializationManager manager, String exceptionText, String helpLink)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeExpression(IDesignerSerializationManager manager, String name, CodeExpression expression)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeExpression(IDesignerSerializationManager manager, String name, CodeExpression expression)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeStatement(IDesignerSerializationManager manager, CodeStatement statement)  

 
Help with this error  
 
MSDN Help   
 

 
Forum posts about this error  
 
Search the MSDN Forums for posts related to this error   
 
 
   

 
 
  
   The variable 'archive1' is either undeclared or was never assigned.     Go to code  
     
 
  
 
  
 
Instances of this error (1)  
 
1.   Abu Fas Homeindex.Designer.cs Line:63 Column:1   Show Call Stack  
 
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.Error(IDesignerSerializationManager manager, String exceptionText, String helpLink)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeExpression(IDesignerSerializationManager manager, String name, CodeExpression expression)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeExpression(IDesignerSerializationManager manager, String name, CodeExpression expression)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeStatement(IDesignerSerializationManager manager, CodeStatement statement)  

 
Help with this error  
 
MSDN Help   
 

 
Forum posts about this error  
 
Search the MSDN Forums for posts related to this error   
 
 
   

 
 
  
   The variable 'borrow1' is either undeclared or was never assigned.     Go to code  
     
 
  
 
  
 
Instances of this error (1)  
 
1.   Abu Fas Homeindex.Designer.cs Line:66 Column:1   Show Call Stack  
 
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.Error(IDesignerSerializationManager manager, String exceptionText, String helpLink)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeExpression(IDesignerSerializationManager manager, String name, CodeExpression expression)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeExpression(IDesignerSerializationManager manager, String name, CodeExpression expression)
at System.ComponentModel.Design.Serialization.CodeDomSerializerBase.DeserializeStatement(IDesignerSerializationManager manager, CodeStatement statement)  

 
Help with this error  
 
MSDN Help   
 

 
Forum posts about this error  
 
Search the MSDN Forums for posts related to this error   
 
 
   

 
 
*/