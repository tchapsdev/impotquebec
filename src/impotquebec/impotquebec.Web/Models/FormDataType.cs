namespace impotquebec.Web.Models
{
    public class FormDataType
    {
        public int FormDataTypeId { get; set; }
        public string Name { get; set; }

        public bool IsTextBox => Name == "Text" || Name == "Number" || Name == "Date";
        public bool IsCheckBox => Name == "Checkbox";
        public bool IsCheckboxList => Name == "CheckboxList";
        public bool IsDropdown => Name == "Dropdown";
        public bool IsRadio => Name == "Radio";
    }
}
