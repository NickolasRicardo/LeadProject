import { Email, Phone, Place, Work } from '@mui/icons-material'
import { Avatar, Grid } from '@mui/material'

type AcceptedCardProps = {
  name: string
  createdAt: Date
  suburb: string
  category: number
  id: number
  description: string
  price: number
  email: string
  phone: string
}

export function convertCategory(category: number) {
  switch (category) {
    case 1:
      return 'Painters'
    case 2:
      return 'Interior Painters'
    case 3:
      return 'General Building Work'
    case 4:
      return 'Home Renovations'
  }
}

export function AcceptedCard({
  category,
  createdAt,
  description,
  id,
  name,
  suburb,
  price,
  email,
  phone,
}: AcceptedCardProps) {
  function stringToColor(string: string) {
    let hash = 0
    let i

    /* eslint-disable no-bitwise */
    for (i = 0; i < string.length; i += 1) {
      hash = string.charCodeAt(i) + ((hash << 5) - hash)
    }

    let color = '#'

    for (i = 0; i < 3; i += 1) {
      const value = (hash >> (i * 8)) & 0xff
      color += `00${value.toString(16)}`.slice(-2)
    }
    /* eslint-enable no-bitwise */

    return color
  }

  function stringAvatar(name: string) {
    const newName =
      name.split(' ').length > 1
        ? `${name[0]}${name.split(' ')[name.split(' ').length - 1][0]}`
        : `${name[0]}`

    return {
      sx: {
        bgcolor: stringToColor(name),
      },
      children: newName,
    }
  }

  return (
    <Grid
      container
      style={{
        height: 300,
        background: 'white',
      }}
    >
      <Grid
        item
        xs={12}
        style={{
          maxHeight: '15%',
          marginTop: '10px',
          marginBottom: '10px',
          paddingBottom: '10px',
        }}
      >
        <Grid
          container
          style={{
            paddingBottom: '5px',
            borderBottom: '1px solid black',
          }}
        >
          <Grid
            item
            xs={2}
            style={{
              alignContent: 'center',
              display: 'flex',
              justifyContent: 'center',
              alignSelf: 'center',
            }}
          >
            <Avatar {...stringAvatar(name)} />
          </Grid>
          <Grid item xs={10}>
            <Grid container>
              <Grid item xs={12}>
                {name}
              </Grid>
              <Grid item xs={12}>
                {new Date(createdAt).toDateString()}
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
      <Grid item xs={12} style={{ borderBottom: '1px solid black' }}>
        <Grid
          container
          style={{
            marginTop: '10px',
            marginBottom: '10px',
          }}
        >
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            <Place />
            {suburb}
          </Grid>
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            <Work /> {convertCategory(category)}
          </Grid>
          <Grid
            item
            xs={2}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            Job ID: {id}
          </Grid>
          <Grid
            item
            xs={2}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            ${price} Lead Invitation
          </Grid>
        </Grid>
      </Grid>
      <Grid item xs={12} style={{ minHeight: '50%' }}>
        <Grid container>
          <Grid
            item
            xs={6}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
              color: 'orange',
            }}
          >
            <Phone style={{ color: 'black' }} /> {phone}
          </Grid>
          <Grid
            item
            xs={6}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
              color: 'orange',
            }}
          >
            <Email style={{ color: 'black' }} /> {email}
          </Grid>
          <Grid item xs={12}>
            <p style={{ padding: '10px' }}>{description}</p>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  )
}
