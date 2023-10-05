import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://localhost:7248/api/Battleship/game'
  
  constructor(private httpClient:HttpClient) { }

  getGameData(id:string)
  {
    return this.httpClient.get<any>(this.baseUrl+`/${id}`);
  }

  shot(x:number,y:number,id:string)
  {    
    const shotData = 
    {
      X:x,
      Y:y
    };
    return this.httpClient.post(this.baseUrl+`/${id}`,shotData)
  }

  createNewGame()
  {
    return this.httpClient.post(this.baseUrl,null)
  }
}
