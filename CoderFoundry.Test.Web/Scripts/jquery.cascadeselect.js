/*
* jQuery Cascading Select Lists plug-in 0.8
*
* Licensed under the "do whatever you want with it" licence.

*/

(function($) {
    $.extend($.fn, {
        cascade: function(options) {
            var dependentDdl = $('#' + options.cascaded);
            options = $.extend({}, $.fn.cascade.defaults, {
                source: options.source, // Source's url
                cascaded: options.cascaded // The ddl element that depends on this list
            }, options);
            if (dependentDdl.children().length == 0) {
                dependentDdl.append('<option value="">' + options.dependentStartingLabel + '</option>');
                if (options.disableUntilLoaded) {
                    dependentDdl.attr('disabled', 'disabled');
                }
            }

            return this.each(function() {
                var sourceDdl = $(this);

                sourceDdl.change(function() {
                    var extraParams = {
                        timestamp: +new Date()
                    };

                    $.each(options.extraParams, function(key, param) {
                        extraParams[key] = typeof param == "function" ? param() : param;
                    });

                    /* Dynamically instantiating an object with a passed in property name */
                    var selectedValueObject = {};
                    selectedValueObject[options.sourceSelectedValueParameterName] = $(this).val();
                    var data = $.extend(selectedValueObject, extraParams);
                    dependentDdl.reload({
                        dependentNothingFoundLabel: options.dependentNothingFoundLabel,
                        dependentStartingLabel: options.dependentStartingLabel,
                        dependentLoadingLabel: options.dependentLoadingLabel,
                        spinnerClass: options.spinnerClass,
                        selectedValues: options.selectedValues,
                        selectedValue: options.selectedValue,
                        selectedValuesString: options.selectedValuesString,
                        source: options.source,
                        extraParams: data
                    });
                });
            });
        }
    });

    $.fn.cascade.defaults = {
        sourceStartingLabel: "Select one first",
        sourceSelectedValueParameterName: "sourceSelectedValue",
        dependentNothingFoundLabel: "No elements found",
        dependentStartingLabel: "Select one",
        dependentLoadingLabel: "Loading options",
        disableUntilLoaded: true,
        spinnerClass: "cascading-select-spinner",
        selectedValues: "",
        selectedValue: "",
        selectedValuesString: "",
        extraParams: {}
    };
})(jQuery);

(function ($) {
    $.extend($.fn, {
        reload: function (options, callback) {
            var sourceDdl = $(this);

            if(options.sel)
            sourceDdl.empty()
                .attr('disabled', 'disabled')
                .append('<option value="">' + options.dependentLoadingLabel + '</option>');
       

            var selectedArray;      /*added by mbt*/
            if (options.selectedValuesString != null)
                selectedArray = options.selectedValuesString.split(',');


            if (options.spinnerImg) {
                sourceDdl.next('.' + options.spinnerClass).remove();

                var spinner = $('<img />').attr('src', options.spinnerImg);
                $('<span class="' + options.spinnerClass + '" />').append(spinner).insertAfter(sourceDdl);
            }
            $.getJSON(options.source, options.extraParams, function(response) {
                sourceDdl.empty().attr('disabled', null);
                sourceDdl.next('.' + options.spinnerClass).remove();
                if (response.length > 0) {
                    if (options.dependentStartingLabel) {
                        sourceDdl.append('<option value="">' + options.dependentStartingLabel + '</option>');
                    }
                    $.each(response, function (i, item) {
                        var selectedText = "";
                        if (item.Value == options.selectedValue || $.inArray(item.Value, options.selectedValues) != -1 || $.inArray(item.Value, selectedArray) != -1) {
                            selectedText = " selected";
                        }
                        
                        sourceDdl.append('<option' + selectedText + ' value=' + item.Value + '>' + item.Text + '</option>');
                    });
                    sourceDdl.change();
                } else {
                    sourceDdl.empty()
                        .attr('disabled', 'disabled')
                        .append('<option value="">' + options.dependentNothingFoundLabel + '</option>');
                }
                sourceDdl.trigger("chosen:updated");
            });
            if (callback && typeof (callback) === "function") {
                callback();
            }
        }
    });
    $.fn.reload.defaults = {
        dependentNothingFoundLabel: "No elements found",
        dependentStartingLabel: "",
        dependentLoadingLabel: "Loading options",
        spinnerClass: "cascading-select-spinner",
        selectedValues: "",
        selectedValue: "",
        selectedValuesString: "",
        extraParams: {}
    };
})(jQuery);