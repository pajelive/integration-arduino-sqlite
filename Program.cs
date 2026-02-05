using System;
using System.IO.Ports;
using Microsoft.Data.Sqlite;

internal class Program
{
    static string connectionString = "Data Source=temp.db";

    private static void Main(string[] args)
    {
        CreateTable();

        // Configure a porta serial conforme sua porta do Arduino
        SerialPort serialPort = new SerialPort("/dev/ttyUSB0", 9600);

        try
        {
            serialPort.Open();
            Console.WriteLine("Conexão estabelecida. Aguardando dados...");

            while (true)
            {
                try
                {
                    // Leia uma linha enviada pelo Arduino (terminada em \n)
                    string data = serialPort.ReadLine().Trim();
                    Console.WriteLine($"Recebido: {data}");
                    Insert(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na leitura: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao abrir a porta serial: {ex.Message}");
        }
        finally
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }
    }
     static void CreateTable()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS historico (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    temp_graus REAL NOT NULL,
                    data TEXT NOT NULL
                );
            ";
            cmd.ExecuteNonQuery();
        }
    }

    static void Insert(string temperatura)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

 
            // insere novo com contador=1
            var insertItemCmd = connection.CreateCommand();
            insertItemCmd.CommandText = "INSERT INTO historico (temp_graus, data) VALUES ($temp_graus, $data)";
            insertItemCmd.Parameters.AddWithValue("$temp_graus", temperatura);
            insertItemCmd.Parameters.AddWithValue("$data", data);
            insertItemCmd.ExecuteNonQuery();
        }
    }
}