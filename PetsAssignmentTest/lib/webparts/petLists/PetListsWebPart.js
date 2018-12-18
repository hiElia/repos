"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var sp_webpart_base_1 = require("@microsoft/sp-webpart-base");
var sp_1 = require("@pnp/sp");
var PetListsWebPart = (function (_super) {
    __extends(PetListsWebPart, _super);
    function PetListsWebPart() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    PetListsWebPart.prototype.onInit = function () {
        var _this = this;
        return _super.prototype.onInit.call(this).then(function (_) {
            sp_1.sp.setup({
                spfxContext: _this.context
            });
        });
    };
    PetListsWebPart.prototype.render = function () {
        this.domElement.innerHTML = "\n      <input type= 'Button' id='CreatePet' value='Create pet' />\n\n      <div>\n      <input type = 'text' id ='petName'\n\n      </div>\n  }\n\n  protected get dataVersion(): Version {\n    return Version.parse('1.0');\n  }\n\n  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {\n    return {\n      pages: [\n        {\n          header: {\n            description: strings.PropertyPaneDescription\n          },\n          groups: [\n            {\n              groupName: strings.BasicGroupName,\n              groupFields: [\n                PropertyPaneTextField('description', {\n                  label: strings.DescriptionFieldLabel\n                })\n              ]\n            }\n          ]\n        }\n      ]\n    };\n  }\n}\n";
    };
    return PetListsWebPart;
}(sp_webpart_base_1.BaseClientSideWebPart));
exports.default = PetListsWebPart;

//# sourceMappingURL=PetListsWebPart.js.map
