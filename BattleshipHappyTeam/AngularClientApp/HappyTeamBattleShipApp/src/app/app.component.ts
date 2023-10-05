import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'HappyTeamBattleShipApp';
  public game:any = [];
  public isGameOver:boolean=false

  constructor(private service:ApiService, private cdr:ChangeDetectorRef){}

  receiveData(refresh:boolean){
    if(refresh)
    {     
      this.getData(this.game.id)    
      
      if(this.game.player1Points>=this.game.gamePoints || this.game.player2Points>=this.game.gamePoints)
      {
        this.isGameOver = true
      }  

      this.cdr.detectChanges();  
    }
  }

  public newGame()  {
    return this.service.createNewGame()
    .subscribe(response=>{
      this.game = response     
    }); 
  }

  public loadGame(inputValue:string){
    return this.getData(inputValue)
  }

  ngOnInit(){
    if(this.game?.id==null)
    {
      return
    }

    return this.getData(this.game.Id);
  }

  private getData(id:string){
    return this.service.getGameData(id)
    .subscribe(response=>{
      this.game = response     
    }); 
  } 
}

