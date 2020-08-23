import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { SpentService } from '../spent.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-spent-field-create',
    templateUrl: './spent-field-create.component.html',
    styleUrls: ['./spent-field-create.component.css']
})
export class SpentFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private spentService: SpentService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
