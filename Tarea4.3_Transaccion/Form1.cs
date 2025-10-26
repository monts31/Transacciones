using System.Runtime.InteropServices.Marshalling;

namespace Tarea4._3_Transaccion
{
    using POJO;
    using Backend;
    using System.Runtime.CompilerServices;

    public partial class Form1 : Form
    {
        private List<Producto> listaProductos = new List<Producto>();
        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }

        public void Iniciar()
        {
            Form1_Load(this, EventArgs.Empty);
        }

        public async Task AgregarProducto(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    string code = txtCode.Text;
                    DaoProductos daoProducts = new DaoProductos();
                    Producto producto = await daoProducts.BuscarProducto(code);

                    if (producto == null) throw new Exception("Producto no encontrado");
                    listaProductos.Add(producto);
                    dataGridView1.DataSource = listaProductos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Codigo", "Código");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Descripcion", "Descripción");
            dataGridView1.Columns.Add("Stock", "Stock");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("Estado", "Estado");
            dataGridView1.Columns.Add("FechaActualizacion", "Fecha Actualización");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDescontinuar_Click(object sender, EventArgs e)
        {
            if(listaProductos.Count == 0)
            {
                MessageBox.Show("No hay productos para descontinuar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que quieres borrar productos?",
                "Confirmación",                            
                MessageBoxButtons.YesNo,                     
                MessageBoxIcon.Question                      
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    DaoProductos daoProducts = new DaoProductos();
                    if (daoProducts.DescontinuarProductos(listaProductos))
                    {
                        listaProductos.Clear();
                        dataGridView1.DataSource = null;
                        MessageBox.Show("Productos descontinuados correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al descontinuar productos: " + ex.Message);
                }
            }
        }
    }
}
