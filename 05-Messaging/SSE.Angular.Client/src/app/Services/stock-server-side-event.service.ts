import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockServerSideEventService {

  constructor() { }
  getStockStream(): Observable<any> {
    const eventSource = new EventSource('https://localhost:7247/stock-updates');

    return new Observable(observer => {
        eventSource.onmessage = event => {
          const messageData= JSON.parse(event.data);
          observer.next(messageData);
      };
    });
 }
}
