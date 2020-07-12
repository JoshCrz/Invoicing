import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  @Input() textClass: string;
  @Input() text: string;
  @Input() icon: string;
  @Input() loading: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
