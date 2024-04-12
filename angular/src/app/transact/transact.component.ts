import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-transact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './transact.component.html',
  styleUrl: './transact.component.css'
})
export class TransactComponent {
  
  @ViewChild('numberInputRef')
  numberInputRef!: ElementRef<HTMLInputElement>;

  onKeyPress(event: KeyboardEvent) {
    const char = String.fromCharCode(event.charCode);
    const allowedChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'];

    // ... (rest of your validation logic)

    if (!allowedChars.includes(char) && event.charCode !== 0) {
      event.preventDefault();
      this.numberInputRef.nativeElement.classList.add('invalid'); // Access classList on the element
    } else {
      this.numberInputRef.nativeElement.classList.remove('invalid');
    }
  }
}
