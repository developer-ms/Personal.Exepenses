import { Component, OnInit, ViewChild, Output, EventEmitter, ChangeDetectorRef,OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule, FormGroup, FormControl} from '@angular/forms';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { SpentService } from './spent.service';
import { ViewModel } from '../../common/model/viewmodel';
import { GlobalService, NotificationParameters} from '../../global.service';
import { ComponentBase } from '../../common/components/component.base';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-spent',
    templateUrl: './spent.component.html',
    styleUrls: ['./spent.component.css'],
})
export class SpentComponent extends ComponentBase implements OnInit, OnDestroy {

    vm: ViewModel<any>;
    changeCultureEmitter: Subscription;

    
    constructor(private spentService: SpentService, private router: Router, private ref: ChangeDetectorRef) {

        super();
        this.vm = null;
    }

    ngOnInit() {

        this.vm = this.spentService.initVM();
        this.updateCulture();

        this.changeCultureEmitter = GlobalService.getChangeCultureEmitter().subscribe((culture : any) => {
            this.updateCulture(culture);
        });

    }

    updateCulture(culture: string = null)
    {
        this.spentService.updateCulture(culture).then((infos : any) => {
            this.vm.infos = infos;
            this.vm.grid = this.spentService.getInfoGrid(infos);
        });
    }

    ngOnDestroy() {
        this.changeCultureEmitter.unsubscribe();
        this.spentService.detectChangesStop();
    }

}
