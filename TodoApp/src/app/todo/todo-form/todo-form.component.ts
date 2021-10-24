import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TodoListService } from '../todo-list/todo-list.service';
import { Todo } from './../../_models/Todo';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-todo-form',
  templateUrl: './todo-form.component.html',
  styleUrls: ['./todo-form.component.css']
})
export class TodoFormComponent implements OnInit {

  @Output() itemAdded = new EventEmitter();

  constructor(private todoService:TodoListService, private nzService: NzMessageService) { }

  ngOnInit(): void {
  }

  addTodo(form:NgForm):void{
    let todo:Todo = {
      title : form.value.title,
      id : 0,
      completed : false,
      completedOn : new Date(),
      AddedOn: new Date()
    };

    this.todoService.AddTodo(todo).subscribe(res => {
      if(res.success == true){
        form.reset();
        this.itemAdded.emit();
        this.nzService.success("Added");
      }
    })
  }
}
