using System.Net;
using System.Text;
using RabbitMQ.Client;
using StackExchange.Redis;
using System.Data.SqlClient;
using Nest;
using Elasticsearch.Net;

namespace Test
{
    public partial class Form1 : Form
    {
        private const int DefaultRedisPort = 6379; 
        private ConnectionMultiplexer redisConnection;
        private static readonly Int32 db = 0; 
        private IElasticClient _elasticClient;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtrabbit_Click(object sender, EventArgs e)
        {
            txtrabbit.Text = string.Empty;
        }

        private void btnrabbit_Click(object sender, EventArgs e)
        {
            string rabbitMQHostName = txtrabbit.Text;
            if (!string.IsNullOrWhiteSpace(rabbitMQHostName))
            {
                if (IsValidIPAddress(rabbitMQHostName))
                {
                    try
                    {
                        var factory = new ConnectionFactory() { HostName = rabbitMQHostName };

                        using (var conn = factory.CreateConnection())
                        using (var channel = conn.CreateModel())
                        {
                            channel.QueueDeclare(queue: "Test",
                                                 durable: false,
                                                 exclusive: false,
                                                 autoDelete: false,
                                                 arguments: null);

                            string message = "Selam, RabbitMQ!";

                            byte[] body = Encoding.UTF8.GetBytes(message);

                            channel.BasicPublish(exchange: "", routingKey: "selam", basicProperties: null, body: body);

                            MessageBox.Show("Mesaj başarıyla gönderildi.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bağlantı Hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz IP adres formatı. Geçerli formatta IP adresi girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("IP adres girilmelidir, boş bırakılamaz. Geçerli IP adresi girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool IsValidIPAddress(string ipAddressString)
        {
            IPAddress? ipAddress = null;
            return IPAddress.TryParse(ipAddressString, out ipAddress) && !IPAddress.IsLoopback(ipAddress);
        }

        //*******************************************************-------------------REDİS-------------------------*********************************************
        private void txtredis_Click(object sender, EventArgs e)
        {
            txtredis.Text = string.Empty;
        }
        private void btnredis_Click(object sender, EventArgs e)
        {
            string redisServerIP = txtredis.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(redisServerIP))
            {
                MessageBox.Show("IP adres girilmelidir, boş bırakılamaz. Geçerli IP adresi girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidIpAddress(redisServerIP))
            {
                MessageBox.Show("Geçersiz IP adres formatı. Geçerli formatta IP adresi girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var redisOptions = new ConfigurationOptions
            {
                EndPoints = { { redisServerIP, DefaultRedisPort } },
                AbortOnConnectFail = false,
            };

            try
            {
                redisConnection = ConnectionMultiplexer.Connect(redisOptions);

                var db = redisConnection.GetDatabase();
                db.StringSet("IdltestKey", "Hello, Redis!");

                var value = db.StringGet("sampleKey");

                MessageBox.Show("Redis bağlantısı başarıyla gerçekleştirildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı Hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidIpAddress(string ipAddress)
        {
            IPAddress? address;
            return IPAddress.TryParse(ipAddress, out address);
        }

        //*******************************************************-------------------MSSQL-------------------------*********************************************

        private void txtsqlswpass_Click(object sender, EventArgs e)
        {
            txtsqlswpass.Text = string.Empty;
            this.txtsqlswpass.PasswordChar = '●';
        }
        private void chksqlswpass_CheckedChanged_1(object sender, EventArgs e)
        {
            txtsqlswpass.PasswordChar = chksqlswpass.Checked ? '\0' : '●';
        }
        private void txtsqlswuname_Click(object sender, EventArgs e)
        {
            txtsqlswuname.Text = string.Empty;
        }
        private void txtsqlswname_Click(object sender, EventArgs e)
        {
            txtsqlswname.Text = string.Empty;
        }


        private void btnsql_Click(object sender, EventArgs e)
        {
            string serverName = txtsqlswname.Text.Trim();
            string username = txtsqlswuname.Text.Trim(); 
            string password = txtsqlswpass.Text; 

            string databaseName = "NewDatabase";
            string tableName = "NewTable";

            if (string.IsNullOrWhiteSpace(serverName))
            {
                MessageBox.Show("IP adres girilmelidir, boş bırakılamaz. Geçerli IP adresi girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidIP(serverName) && !IsValidHostname(serverName))
            {
                MessageBox.Show("IP adres girilmelidir, boş bırakılamaz. Geçerli IP adresi girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string masterConnectionString = $"Data Source={serverName};Initial Catalog=master;User ID={username};Password={password}";

            string createDatabaseSql = $"CREATE DATABASE [{databaseName}]";
            string createTableSql = $"USE [{databaseName}]; CREATE TABLE [{tableName}] (Id INT IDENTITY(1,1), ColumnName NVARCHAR(255))";

            using (SqlConnection masterConnection = new SqlConnection(masterConnectionString))
            {
                try
                {
                    masterConnection.Open();

                    // Create the new database
                    using (SqlCommand createDbCommand = new SqlCommand(createDatabaseSql, masterConnection))
                    {
                        createDbCommand.ExecuteNonQuery();
                    }

                    masterConnection.ChangeDatabase(databaseName);

                    using (SqlCommand createTableCommand = new SqlCommand(createTableSql, masterConnection))
                    {
                        createTableCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Sql server bağlantısı gerçekleştirildi. Test için database ve table oluşturuldu.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bağlantı Hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValidIP(string ipAddress)
        {
            IPAddress? addr;
            return IPAddress.TryParse(ipAddress, out addr);
        }

        private bool IsValidHostname(string hostname)
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(hostname);
                return host.AddressList.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //*******************************************************-------------------ELASTİCSEARCH-------------------------*********************************************
        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = string.Empty;
            this.txtPassword.PasswordChar = '●';
        }

        private void chkelk_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkelk.Checked ? '\0' : '●';
        }

        private void txtELK_Click(object sender, EventArgs e)
        {
            txtELK.Text = string.Empty;
        }

        private void txtUname_Click(object sender, EventArgs e)
        {
            txtUname.Text = string.Empty;
        }

        private void txtIndex_Click(object sender, EventArgs e)
        {
            txtIndex.Text = string.Empty;
        }

        private void txtLevel_Click(object sender, EventArgs e)
        {
            txtLevel.Text = string.Empty;
        }

        private void txtMessage_Click(object sender, EventArgs e)
        {
            txtMessage.Text = string.Empty;
        }

        private void InitializeElasticsearchClient()
        {
            try
            {
                var elasticsearchUrl = txtELK.Text;
                var indexName = txtIndex.Text;
                var username = txtUname.Text;
                var password = txtPassword.Text;

                var settings = new ConnectionSettings(new Uri(elasticsearchUrl))
                    .BasicAuthentication(username, password);

                _elasticClient = new ElasticClient(settings);

                MessageBox.Show("Elasticsearch bağlantısı başarıyla kuruldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Elasticsearch bağlantısı kurulurken bir hata oluştu: {ex.Message}");
            }
        }
        private void btnelk_con_Click(object sender, EventArgs e)
        {
            InitializeElasticsearchClient();
        }
        private void btnELK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_elasticClient == null)
                {
                    MessageBox.Show("Elasticsearch bağlantısı kurulu değil. Önce bağlantıyı kurun.");
                    return;
                }

                var testData = new
                {
                    Timestamp = DateTime.UtcNow,
                    Message = txtMessage.Text,  
                    Level = txtLevel.Text  
                };

                var indexResponse = _elasticClient.Index(testData, idx => idx
                    .Index(txtIndex.Text)
                );

                if (indexResponse.IsValid)
                {
                    MessageBox.Show("Test verisi Elasticsearch'e başarıyla gönderildi.");
                    
                    this.Invalidate();
                }
                else
                {
                    MessageBox.Show($"Test verisi gönderirken bir hata oluştu: {indexResponse.DebugInformation}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Test verisi gönderirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
