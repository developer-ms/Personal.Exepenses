import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { SpentService } from '../spent.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-spent-field-edit',
    templateUrl: './spent-field-edit.component.html',
    styleUrls: ['./spent-field-edit.component.css']
})
export class SpentFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
