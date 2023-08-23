
public class Task
{

	public Task()
	{
		CreatedAt = DateTime.Now;
	}


	public int Id { get; set; }

	public string Title { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public string Email { get; set; }

	public DateTime CreatedAt { get; set; }

        public void Update(string title, string name, string description, string email)
        {
            Title = title;
            Name = name;
            Description = description;
            Email = email;
        }


    }


