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

 processEventStream(): void {
  //TODO-RnD ; How to pass header with EventSource
  const eventSource = new EventSource('https://localhost:7247/stock-updates');
      eventSource.onmessage = event => {
        const messageData= JSON.parse(event.data);
        console.warn(messageData);
        
    };

    eventSource.onerror = (err)=> {
      if (err) {
            console.warn(err);
        
      }
    };
  
}



readStream(){
// Fetch the event stream from the server
fetch('https://localhost:7247/stock-updates')
    .then(response => {
        // Get the readable stream from the response body
        const stream = response.body;
        // Get the reader from the stream
        const reader = stream?.getReader();
        // Define a function to read each chunk
        const readChunk = () => {
            // Read a chunk from the reader
            reader?.read()
                .then(({value,done}) => {
                    // Check if the stream is done
                    if (done) {
                        // Log a message
                        console.log('Stream finished');
                        // Return from the function
                        return;
                    }
                    // Convert the chunk value to a string
                    console.warn(value);
                    const chunkString = new TextDecoder().decode(value);
                    // Log the chunk string
                    console.log(chunkString);

                    // Read the next chunk
                    readChunk();
                })
                .catch(error => {
                    // Log the error
                    console.error(error);
                });
        };
        // Start reading the first chunk
        readChunk();
    })
    .catch(error => {
        // Log the error
        console.error(error);
    });
}
}
