using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Drawing.Text;

public struct jsonRow
{
    public int Id { get; set; }
    public String Title { get; set; }
}

public class Form1 : Form
{
    private DataGridView jsonDataGridView = new DataGridView();

    private HttpClient httpClient = new HttpClient()
    {
        BaseAddress = new Uri("https://my-json-server.typicode.com")
    };

    public Form1() 
    {
        this.Load += new EventHandler(Form1_Load);
    }

    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        SetupLayout();
        SetupDataGridView();
        PopulateDataGridView();
    }
    
    private void SetupLayout()
    {
        this.Name = "Form1";
        this.Text = "Form1";
        this.Size = new System.Drawing.Size(800, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void SetupDataGridView()
    {
        this.Controls.Add(jsonDataGridView);

        jsonDataGridView.ColumnCount = 2;
        jsonDataGridView.Name = "jsonDataGridView";
        jsonDataGridView.Location = new Point(8, 8);
        jsonDataGridView.Size = new Size(500, 250);

        jsonDataGridView.Columns[0].DisplayIndex = 0;
        jsonDataGridView.Columns[1].DisplayIndex = 1;
        jsonDataGridView.Columns[0].Name = "ID";
        jsonDataGridView.Columns[1].Name = "Title";
        jsonDataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
        jsonDataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
    }

    private async void PopulateDataGridView()
    {
        using (HttpResponseMessage httpResponse = await httpClient.GetAsync("typicode/demo/posts"))
        {
            try
            {
                httpResponse.EnsureSuccessStatusCode();

                if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var jsonResponse = await httpResponse.Content.ReadFromJsonAsync<List<jsonRow>>();

                    foreach (var jsonRow in jsonResponse)
                    {
                        jsonDataGridView.Rows.Add(jsonRow.Id, jsonRow.Title);
                    }
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}