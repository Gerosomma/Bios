<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Detalle Tramite</title>
      </head>
      <body>
        <h2>Tramite: </h2>
        Codigo: <xsl:value-of select="/Tramite/codigo"/>
        <br />
        Nombre: <xsl:value-of select="/Tramite/nombre"/>
        <br />
        Descripcion: <xsl:value-of select="/Tramite/descripcion"/>
        <br />
        Precio: $<xsl:value-of select="/Tramite/precio"/>
        <br />
        <h3>Documentacion exigida:</h3>
        Codigo: <xsl:value-of select="/Tramite/DocumentacionExigida/Documento/codigo"/>
        <br />
        Documento: <xsl:value-of select="/Tramite/DocumentacionExigida/Documento/nombre"/>
        <br />
        Lugar gestion documento: <br /><xsl:value-of select="/Tramite/DocumentacionExigida/Documento/lugar"/>
        <br />
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
