using Microsoft.AspNetCore.Mvc;

namespace TasksAPI.Entities;

using TasksAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




    [ApiController]
	[Route("api/tasks")]


	public class TasksController: ControllerBase
	{
		private readonly TasksDbContext _context;
    private Task task;

    public TasksController(TasksDbContext context)
		{
			_context = context;
		}


		[HttpGet]
		public IActionResult GetAll()

		{

			var tasks = _context.Tasks.ToList();


			return Ok(tasks);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var task = _context.Tasks.SingleOrDefault(j => j.Id == id);

			if (task == null)
			{

				return NotFound();
			}


			return Ok(task);

		}

		[HttpPost]
		public IActionResult Post (Task Task)

		{
			_context.Tasks.Add(task);
			_context.SaveChanges();

			return CreatedAtAction(nameof(GetById), new { id = Task.Id }, Task);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, Task input)
		{
            var task = _context.Tasks
				.SingleOrDefault(j => j.Id == id);

            if (task == null)
            {

                return NotFound();
            }

           task.Update(input.Title, input.Name, input.Description, input.Email);

			_context.Tasks.Update(task);
			_context.SaveChanges();

			return NoContent();


		}

		[HttpDelete("{id}")]
		public IActionResult Delete (int id)
		{

            var task = _context.Tasks
                .SingleOrDefault(j => j.Id == id);

            if (task == null)
            {

                return NotFound();
            }

			_context.Tasks.Remove(task);
			_context.SaveChanges();

            return NoContent();


		}



	}


