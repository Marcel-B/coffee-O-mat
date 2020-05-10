using System;

namespace com.b_velop.coffee_O_mat.Domain.Models
{
    public class Brew
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public double Temperature { get; set; }
        public double TargetTemperature { get; set; }
        public double Output { get; set; }
        public double KP { get; set; }
        public double KI { get; set; }
        public double KD { get; set; }
    }
}