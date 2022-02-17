using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Reader.Model
{
    public class Genre
    {
        
        public int Id { get; set; }

        public string Type { get; set; }

        // Mettez ici les propriété de votre livre: Nom et Livres associés

        // N'oublier pas qu'un genre peut avoir plusieur livres
        [JsonIgnore]
        public List<Book> Books { get; set; }
    }

}

