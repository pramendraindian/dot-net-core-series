import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockServerSideEventService {

  constructor() { }
  getStockStream(): Observable<any> {
    const eventSource = new EventSource('https://localhost:7247/stock-updates/PPS');

    return new Observable(observer => {
        eventSource.onmessage = event => {
          const messageData= JSON.parse(event.data);
          observer.next(messageData);
      };
    });
 }

 processEventStream(): void {
  //TODO-RnD ; How to pass header with EventSource
  const eventSource = new EventSource('https://localhost:7247/stock-updates/PPS');
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
fetch('https://localhost:7247/stock-updates/PPS')
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
                    //console.warn(value);
                    const chunkString = new TextDecoder().decode(value,{ stream: true });
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

rs(){
  fetch("https://localhost:7247/stock-updates/MSFT",{
    method: 'POST',
    headers: {
      'X-My-Custom-Header': 'value-v',
      'Authorization': 'Bearer ' + 'XYZZZZZ',
      'UserId': 'PPS',
    },
    body: 'Pramendra'
  })
  .then((response) => response.body)
  .then((rb) => {
    const reader = rb?.getReader();

    return new ReadableStream({
      start(controller) {
        // The following function handles each data chunk
        function push() {
          // "done" is a Boolean and value a "Uint8Array"
          reader?.read().then(({ done, value }) => {
            // If there is no more data to read
            if (done) {
              console.log("done", done);
              controller.close();
              return;
            }
            // Get the data and send it to the browser via the controller
            controller.enqueue(value);
            // Check chunks by logging to the console
            //console.log(done, value);
            const chunkString = new TextDecoder().decode(value,{ stream: true });
            // Log the chunk string
            //console.log(chunkString);
            console.log(JSON.parse(chunkString));
            push();
          });
        }

        push();
      },
    });
  })
  .then((stream) =>
    // Respond with our stream
    new Response(stream, { headers: { "Content-Type": "text/html" } }).text(),
  )
  .then((result) => {
    // Do things with result
    console.log(result);
  });
}

}
