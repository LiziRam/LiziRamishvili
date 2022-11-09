using System;
namespace Practice_10._1
{
    class Cat
    {
        string _name;
        string _breed;
        int _age;
        string _sex;
        int portion = 10;
        
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if(value > 0)
                {
                    _age = value;
                }
            }
        }
        public string Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                if(value == "male" || value == "female" || value == "Male" || value == "Female")
                {
                    _sex = value;
                }
            }
        }

        public void Eat(int food)
        {
            int currPortions = food / portion;
            if (food % portion != 0)
            {
                currPortions = currPortions + 1;
            }
            
            for(int i = 0; i < currPortions; i++)
            {
                Console.WriteLine("Eating...");
            }
        }

        public void Meowing(int meow)
        {
            for(int i = 0; i < meow; i++)
            { 
                Console.WriteLine("Meowing...");
            }
        }

    }
}

