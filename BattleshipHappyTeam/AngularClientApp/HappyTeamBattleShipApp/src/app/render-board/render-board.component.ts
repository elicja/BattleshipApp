import { Component,EventEmitter, Output, Input,ChangeDetectorRef } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-render-board',
  templateUrl: './render-board.component.html',
  styleUrls: ['./render-board.component.css']
})
export class RenderBoardComponent {
  constructor(private service:ApiService,private cdr:ChangeDetectorRef){}

   @Input() title:string="";
   @Input() board:number[][] = []
   @Input() canMove:boolean = false
   @Input() id:string = ""

   @Output() refreshEvent = new EventEmitter<boolean>();

   public makeAMove(x:number,y:number,v:number){
    if(!this.canMove || v != 0)
    {
      return
    }

    this.service.shot(x,y,this.id).subscribe((response) => {
      console.log(response);
      this.refreshEvent.emit(true)
      this.cdr.detectChanges()
    });    
   }

   public getCssClass(v:number){
    switch(v){
      case -1:
        return "bg-danger";
      case 1:
        return "bg-success"
      case 5:
        return "bg-info"
      case 0:
        if(this.canMove)
        {
          return "notHittedField"
        }
        return ""
      default:
        return ""
    }
   }
   
}
