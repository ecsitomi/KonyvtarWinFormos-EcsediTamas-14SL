using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KonyvtarWinFormos_EcsediTamas_14SL
{
    internal class Adatbazis
    {
        MySqlConnection connection;
        MySqlCommand command;

        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "books";
            builder.CharacterSet = "utf8";
            connection = new MySqlConnection(builder.ConnectionString);
            command = connection.CreateCommand();
            try
            {
                nyit();
                zar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void nyit()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        private void zar()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public List<Book> selectBook()
        {
            List<Book> books = new List<Book>();
            command.CommandText = "SELECT * FROM books";
            nyit();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string author = reader.GetString("author");
                    string title = reader.GetString("title");
                    int publishedYeart = reader.GetInt32("published_year");
                    int pageCount = reader.GetInt32("page_count");
                    int id = reader.GetInt32("id");

                    Book book = new Book(author, id, pageCount, publishedYeart, title);
                    books.Add(book);
                }
            }
            zar();
            return books;
        }
        public void insertBook(Book book)
        {
            command.CommandText = "INSERT INTO `books` (`id`, `author`, `title`, `published_year`, `page_count`,)" 
                + "VALUES (@id, @author, @title, @published_year, @page_count)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@published_year", book.Published_year);
            command.Parameters.AddWithValue("@page_count", book.Page_count);
            //command.Parameters.AddWithValue("id", book.Id);
            nyit();
            command.ExecuteNonQuery();
            zar();
        }
        public void deleteBook(Book book)
        {
            command.CommandText = "DELETE FROM `book` WHERE `id` = @id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", book.Id);
            nyit();
            command.ExecuteNonQuery();
            zar();
        }
        public void updateBook(Book book)
        {
            command.CommandText = "INSERT INTO `books` (`id`, `author`, `title`, `published_year`, `page_count`,)"
                + "VALUES (@id, @author, @title, @published_year, @page_count)" 
                + "WHERE id = @id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@published_year", book.Published_year);
            command.Parameters.AddWithValue("@page_count", book.Page_count);
            command.Parameters.AddWithValue("id", book.Id);
            nyit();
            command.ExecuteNonQuery();
            zar();
        }
    }
}
