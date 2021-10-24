import { Component, OnInit } from '@angular/core';
import { TodoListService } from './todo-list.service';
import { Todo } from 'src/app/_models/Todo';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  todos:any;

  constructor(private todoService:TodoListService, private nzMessageService:NzMessageService) { }

  ngOnInit(): void {
    this.loadAllTodos();
  }

  loadAllTodos = (): void => {
    this.todoService.GetAllTodos().subscribe(data => {
      if(data.success == true){
        this.todos = data.data;
      }
    });
  }

  updateTodo = (todo:Todo): void => {
    this.todoService.UpdateTodo(todo.id, todo).subscribe(data => {
      if(data.success == true){
        this.loadAllTodos();
      }
      this.nzMessageService.info("Updated");
    });
  }

  deleteTodo = (id:number): void => {
    this.todoService.DeleteTodo(id).subscribe(data => {
      if(data.success == true){
        this.todos = this.todos.filter((d:any) => d.id != id);
      }
      this.nzMessageService.warning("Deleted");
    });
  }

  refresh(){
    this.loadAllTodos();
  }

  cancel = () => {
    this.nzMessageService.info("Cancelled");
  }

}
