import { useState } from 'react';
import {
  FormControl,
  InputLabel,
  Select,
  SelectChangeEvent,
  MenuItem,
  Checkbox,
  ListItemText,
} from '@mui/material';

interface Props {
  items: string[];
  checked?: string[];
  onChange?: (items: string[]) => void;
}

export default function RequestTypeSelect({ items }: Props) {
  //const [checkedItems, setCheckedItems] = useState(checked || []);
  const [requestTypeName, setRequestTypeName] = useState<string[]>([]);

  function handleChange(event: SelectChangeEvent<typeof requestTypeName>) {
    //const currentIndex = checkedItems.findIndex((item) => item == value);
    const {
      target: { value },
    } = event;
    setRequestTypeName(typeof value === 'string' ? value.split(',') : value);
  }

  return (
    <FormControl>
      <InputLabel htmlFor='requestType'>Type of Request</InputLabel>
      <Select
        id='requestType'
        name='requestType'
        fullWidth
        variant='filled'
        value={requestTypeName}
        onChange={handleChange}
      >
        {items.map((name) => (
          <MenuItem key={name} value={name}>
            <Checkbox checked={requestTypeName.includes(name)} />
            <ListItemText primary={name} />
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
}
