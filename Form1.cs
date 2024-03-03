using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonyvtarWinFormos_EcsediTamas_14SL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<Book> books = Program.databazis.selectBook();
            listBox1.DataSource = books;
            listBox1.DisplayMember = "ToString";
            urlaptorles();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book kivalasztottKonyv = (Book)listBox1.SelectedItem;
            textBox_id.Text = kivalasztottKonyv.Id.ToString();
            textBox_author.Text = kivalasztottKonyv.Author.ToString();
            textBox_title.Text = kivalasztottKonyv.Title.ToString();
            textBox_pageCount.Text = kivalasztottKonyv.Page_count.ToString();
            textBox_publishedYear.Text = kivalasztottKonyv.Published_year.ToString();
        }
        private void urlaptorles()
        {
            textBox_id.Clear();
            textBox_author.Clear();
            textBox_title.Clear();
            textBox_pageCount.Clear();
            textBox_publishedYear.Clear();
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            Book insertBook = new Book(textBox_author.Text, int.Parse(null), int.Parse(textBox_pageCount.Text), int.Parse(textBox_publishedYear.Text), textBox_title.Text);
            Program.databazis.insertBook(insertBook);
            Form1_Load(sender, e);

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            Book updateBook = new Book(textBox_author.Text, int.Parse(textBox_id.Text), int.Parse(textBox_pageCount.Text), int.Parse(textBox_publishedYear.Text), textBox_title.Text);
            Program.databazis.updateBook(updateBook);
            Form1_Load(sender, e);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            Book deleteBook = new Book(textBox_author.Text, int.Parse(textBox_id.Text), int.Parse(textBox_pageCount.Text), int.Parse(textBox_publishedYear.Text), textBox_title.Text);
            Program.databazis.deleteBook(deleteBook);
            Form1_Load(sender, e);
        }
    }
}
