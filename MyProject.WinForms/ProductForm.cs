using System;
using System.Windows.Forms;
using MyProject.BLL;
using MyProject.DTO;

namespace MyProject.WinForms
{
    public class ProductForm : Form
    {
        DataGridView grid;
        TextBox txtName, txtPrice, txtQty;
        Button btnAdd, btnUpdate, btnDelete;

        ProductService service = new();

        public ProductForm()
        {
            InitUI();
            LoadData();
        }

        void InitUI()
        {
            this.Text = "Products";
            this.Width = 600;
            this.Height = 400;

            grid = new DataGridView { Left = 20, Top = 20, Width = 540, Height = 150 };
            grid.SelectionChanged += Grid_SelectionChanged;

            txtName = new TextBox { Left = 20, Top = 190, Width = 150 };
            txtPrice = new TextBox { Left = 180, Top = 190, Width = 100 };
            txtQty = new TextBox { Left = 290, Top = 190, Width = 100 };

            btnAdd = new Button { Text = "Add", Left = 20, Top = 230 };
            btnUpdate = new Button { Text = "Update", Left = 100, Top = 230 };
            btnDelete = new Button { Text = "Delete", Left = 200, Top = 230 };

            btnAdd.Click += Add_Click;
            btnUpdate.Click += Update_Click;
            btnDelete.Click += Delete_Click;

            Controls.AddRange(new Control[] {
                grid, txtName, txtPrice, txtQty,
                btnAdd, btnUpdate, btnDelete
            });
        }

        void LoadData()
        {
            grid.DataSource = service.GetProducts();
        }

        void Add_Click(object s, EventArgs e)
        {
            service.AddProduct(new ProductDTO
            {
                ProductName = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Quantity = int.Parse(txtQty.Text)
            });
            LoadData();
        }

        void Update_Click(object s, EventArgs e)
        {
            if (grid.CurrentRow == null) return;

            var p = (ProductDTO)grid.CurrentRow.DataBoundItem;
            p.ProductName = txtName.Text;
            p.Price = decimal.Parse(txtPrice.Text);
            p.Quantity = int.Parse(txtQty.Text);

            service.UpdateProduct(p);
            LoadData();
        }

        void Delete_Click(object s, EventArgs e)
        {
            if (grid.CurrentRow == null) return;

            var p = (ProductDTO)grid.CurrentRow.DataBoundItem;
            service.DeleteProduct(p.ProductId);
            LoadData();
        }

        void Grid_SelectionChanged(object s, EventArgs e)
        {
            if (grid.CurrentRow == null) return;

            var p = (ProductDTO)grid.CurrentRow.DataBoundItem;
            txtName.Text = p.ProductName;
            txtPrice.Text = p.Price.ToString();
            txtQty.Text = p.Quantity.ToString();
        }
    }
}