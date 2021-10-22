import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { apiUrl, apiUrlWithId } from 'src/app/Constants/api';
import { Observable } from 'rxjs';
import { JsonResponse } from 'src/app/_models/jsonResponse';
import { Todo } from 'src/app/_models/Todo';

@Injectable({
  providedIn: 'root'
})
export class TodoListService {

  constructor(private http:HttpClient) { }

  // return all todos
  GetAllTodos():Observable<JsonResponse>{
    return this.http.get<JsonResponse>(apiUrl);  
  }

  // find todo
  GetTodoById(id:number):Observable<JsonResponse>{
    return this.http.get<JsonResponse>(`${apiUrlWithId}${id}`);
  }

  // add new todo
  AddTodo(todo:Todo):Observable<JsonResponse>{
    return this.http.post<JsonResponse>(apiUrl, todo);
  }

  // update todo
  UpdateTodo(id:number, todo:Todo):Observable<JsonResponse>{
    return this.http.put<JsonResponse>(`${apiUrlWithId}${id}`, todo);
  }
  
  // delete todo
  DeleteTodo(id:number):Observable<JsonResponse>{
    return this.http.delete<JsonResponse>(`${apiUrlWithId}${id}`);
  }
}
