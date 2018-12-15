using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace MyBlogMVC.Models
{
    public class DataAccess
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        public PostViewModel getPostDetail(int id)
        {
            PostViewModel post = new PostViewModel();
            SetConnection();
            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();
            string CommandText = "SELECT Post.id , title, summary, content, post_date, username ";
            CommandText += "FROM Post, User ";
            CommandText += "where Post.userID = User.ID and Post.ID = " + id;

            sql_cmd.CommandText = CommandText;
            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            while (reader.Read())
            {
                post.postId = Int16.Parse(reader["ID"].ToString());
                post.title = reader["title"].ToString();
                post.summary = reader["summary"].ToString();
                post.content = reader["content"].ToString();
                post.userName = reader["username"].ToString();
                post.postedDate = reader["post_Date"].ToString();
            }
            sql_con.Close();
            return post;
        }

        public List<PostViewModel> LoadData(int page)
        {
            var list = new List<PostViewModel>();
            PostViewModel post;//= new PostViewModel();
            SetConnection();
            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();
            string CommandText = "SELECT Post.id , title, summary, content, post_date, username ";
            CommandText += "FROM Post, User ";
            CommandText += "where Post.userID = User.ID ";
            CommandText += "LIMIT 10 OFFSET " + 10 * (page - 1);

            sql_cmd.CommandText = CommandText;
            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            while (reader.Read())
            {
                post = new PostViewModel();
                post.postId = Int16.Parse(reader["ID"].ToString());
                post.title = reader["title"].ToString();
                post.summary = reader["summary"].ToString();
                post.content = reader["content"].ToString();
                post.userName = reader["username"].ToString();
                post.postedDate = reader["post_Date"].ToString();
                list.Add(post);

            }
            sql_con.Close();
            return list;
        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection(@"Data Source=C:\Users\kk\Documents\Visual Studio 2015\Projects\MyBlogMVC\MyBlogMVC\BlogDB.db;Version=3;New=False;Compress=True;");

        }

        public int PostArticle(Post post)
        {
            SetConnection();
            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();
            string CommandText = "insert into post (title, summary, content, post_date, userID) values('" + post.title+"','"+ post.summary+"','"+post.content+ "','"+post.postedDate+"','"+post.user.userId+"')";
            sql_cmd.CommandText = CommandText;
            int result = sql_cmd.ExecuteNonQuery();
            return result;
        }
    }
}