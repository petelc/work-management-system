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
  const [requestTypeName, setRequestTypeName] = useState<string[]>([]);

  function handleChange(event: SelectChangeEvent<typeof requestTypeName>) {
    const {
      target: { value },
    } = event;
    setRequestTypeName(typeof value === 'string' ? value.split(',') : value);
  }

  return (
    <FormControl variant='filled'>
      <InputLabel id='type'>Type of Request</InputLabel>
      <Select
        labelId='type'
        id='requestType'
        name='requestType'
        fullWidth
        value={requestTypeName}
        onChange={handleChange}
      >
        <MenuItem value=''>
          <em>None</em>
        </MenuItem>
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
