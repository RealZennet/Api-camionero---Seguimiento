﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APICamionero.Models
{
    public class DestinationModel : DatabaseConnector
    {
        public int IDDestination { get; set; }
        public string StreetDestination { get; set; }
        public int DoorNumber { get; set; }
        public string CornerDestination { get; set; }
        public DateTime EstimatedDate { get; set; }
        public bool ActivedDestination { get; set; }

        public List<DestinationModel> GetDestinations()
        {
            List<DestinationModel> destinations = new List<DestinationModel>();

            try
            {
                this.Command.CommandText = "SELECT * FROM destino";
                this.Reader = this.Command.ExecuteReader();

                while (this.Reader.Read())
                {
                    DestinationModel destination = new DestinationModel
                    {
                        IDDestination = Convert.ToInt32(this.Reader["id_des"]),
                        StreetDestination = this.Reader["calle"].ToString(),
                        DoorNumber = Convert.ToInt32(this.Reader["num"]),
                        CornerDestination = this.Reader["esq"].ToString(),
                        EstimatedDate = Convert.ToDateTime(this.Reader["fech_esti"].ToString()),
                        ActivedDestination = Convert.ToBoolean(this.Reader["bajalogica"])
                    };

                    destinations.Add(destination);
                }

                this.Reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return destinations;
        }

        public DestinationModel GetDestinationById(int id)
        {
            try
            {
                this.Command.CommandText = $"SELECT * FROM destino WHERE id_des = {id}";
                this.Reader = this.Command.ExecuteReader();

                if (this.Reader.Read())
                {
                    DestinationModel destination = new DestinationModel
                    {
                        IDDestination = Convert.ToInt32(this.Reader["id_des"]),
                        StreetDestination = this.Reader["calle"].ToString(),
                        DoorNumber = Convert.ToInt32(this.Reader["num"]),
                        CornerDestination = this.Reader["esq"].ToString(),
                        EstimatedDate = Convert.ToDateTime(this.Reader["fech_esti"].ToString()),
                        ActivedDestination = Convert.ToBoolean(this.Reader["bajalogica"])
                    };

                    this.Reader.Close();
                    return destination;
                }

                this.Reader.Close();
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

    }
}
