using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerdiProj1
{
    public class StatusEffects
    {
        public string Status { get; set; }
        public int Damage { get; set; }
        public int Turn { get; set; }

        public StatusEffects( string status, int damage, int turn)
        {
            Status = status;
            Damage = damage;
            Turn = turn;
        }
    }
}
