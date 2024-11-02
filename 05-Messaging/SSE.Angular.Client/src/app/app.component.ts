import { Component,OnInit } from '@angular/core';
import { StockServerSideEventService } from './Services/stock-server-side-event.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SSE.Angular.Client';
  constructor(private stockSSEService:StockServerSideEventService)
  {

  }
  ngOnInit(): void {
    //this.stockSSEService.rs();
    //this.stockSSEService.readStream();
    //this.stockSSEService.processEventStream();
    /*
    this.stockSSEService.getStockStream().subscribe(
      (data) => {
        console.log(`.... ${data?.Name} , Stock Price: ${data?.Price}`);
        document.write(`<p>.... ${data?.Name} , Stock Price: ${data?.Price}</p>`);
      }
    );
    */
  }

}
