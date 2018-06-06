using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeoAttractiveServer.Models
{
    public class SentAttractions
    {
        [Key]
        [Description("ид")]
        public int Id { get; set; }
        [Description("Назваине достопримечательности")]
        public string Name { get; set; }
        [Description("Описание достопримечательности")]
        public string Description { get; set; }
        [Description("Картинка для достопримечательности")]
        public string ImagePath { get; set; }
        [Description("Город")]
        public int Sity { get; set; }
        [Description("Тип достопримечательности")]
        public int Type { get; set; }
        [Description("Широта")]
        public double Lat { get; set; }
        [Description("Долгота")]
        public double Lon { get; set; }
        [Description("Статус")]
        public bool Status { get; set; }
    }
}