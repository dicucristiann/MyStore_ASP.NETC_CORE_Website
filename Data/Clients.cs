namespace PostgreSQL.Data
{
    public class Clients
    {
        public int Id { get; set; } // corespunde coloanei "id" SERIAL PRIMARY KEY
        public string Name { get; set; } // corespunde coloanei "name" VARCHAR (100) NOT NULL
        public string Email { get; set; } // corespunde coloanei "email" VARCHAR (150) NOT NULL UNIQUE
        public string Phone { get; set; } // corespunde coloanei "phone" VARCHAR(20)
        public string Address { get; set; } // corespunde coloanei "address" VARCHAR(100)
        public DateTime CreatedAt { get; set; } // corespunde coloanei "created_at" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
    }
}
